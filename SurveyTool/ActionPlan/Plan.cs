using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SurveyTool.ActionPlan
{
    public enum PlanType
    {
        PerUser,
        PerTrialNo,
        Random
    };

    public class Plan
    {
        public List<IAction> Actions { get; private set; }
        private PlanType mType;
        private string mUser;
        private string mPath;
        private bool mUserRating;
        private string mVideoFilePattern;

        public Plan(string user, string path, PlanType type, bool userRating, string videoFilePattern)
        {
            Actions = new List<IAction>();
            mUser = user;
            mPath = path;
            mType = type;
            mUserRating = userRating;
            mVideoFilePattern = videoFilePattern;

            List<List<IAction>> hActions = TraverseDirectory(path);
            switch (type) {
                case PlanType.PerUser:
                    Actions = hActions.SelectMany(i => i).ToList();
                    break;
                case PlanType.PerTrialNo:
                    var max = 0;
                    foreach (var list in hActions) {
                        max = (max < list.Count) ? list.Count : max;
                    }
                    for (int level=0; level<max; level++) {
                        foreach (var list in hActions) {
                            if (list.Count > level) {
                                Actions.Add(list[level]);
                            }
                        }
                    }
                    break;
                case PlanType.Random:
                    var rnd = new Random();
                    List<IAction> dActions = hActions.SelectMany(i => i).ToList();
                    while (dActions.Count != 0) {
                        var pos = rnd.Next() % dActions.Count;
                        Actions.Add(dActions[pos]);
                        dActions.RemoveAt(pos);
                    }
                    break;
            }
        }

        private List<List<IAction>> TraverseDirectory(string currentPath)
        {
            List<List<IAction>> hActions = new List<List<IAction>>();

            List<IAction> actions = new List<IAction>();
            List<string> videos = new List<string>();

            // Search the current directory for video files:
            foreach (string file in Directory.EnumerateFiles(currentPath, mVideoFilePattern).OrderBy(s=>s)) {
                TrialRating tr = new TrialRating(mUser, file);
                if (!tr.AlreadyRated) {
                    actions.Add(tr);
                }
                videos.Add(file);
            }

            if (mUserRating && (actions.Count != 0)) {
                UserRating ur = new UserRating(mUser, currentPath, videos.ToArray());
                if (!ur.AlreadyRated) {
                    actions.Add(ur);
                }
            }

            if (actions.Count != 0) {
                hActions.Add(actions);
            }

            // Search directories deeply:
            foreach (string dir in Directory.EnumerateDirectories(currentPath).OrderBy(s => s)) {
                foreach (List<IAction> list in TraverseDirectory(dir)) {
                    hActions.Add(list);
                }
            }

            return hActions;
        }

        public override string ToString()
        {
            StringWriter sw = new StringWriter();
            foreach (var action in Actions) {
                sw.WriteLine(action.ToString());
            }

            return sw.ToString();
        }
    }
}
