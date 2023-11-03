using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeadCode.Medium
{
    public class RankTeamByVotes
    {
        class group
        {
            public int position { set; get; }
            public char charx { set; get; }
            public int freq { set; get; }
        }
        public string RankTeams(string[] votes)
        {

            if (votes.Length == 1) return votes[0];

            List<group> ranks = new List<group>();
            StringBuilder ans = new StringBuilder();

            for (int i = 0; i < votes.Length; i++)
            {
                char[] a = votes[i].ToCharArray();

                for (int j = 0; j < a.Length; j++)
                {
                    var exist = ranks.Where(x => x.charx == a[j] && x.position == (j + 1))
                        .Select(x => x)
                        .FirstOrDefault();
                    if (exist == null)
                    {
                        var data = new group
                        {
                            position = j + 1,
                            charx = a[j],
                            freq = 1
                        };
                        ranks.Add(data);
                    }
                    else
                    {
                        ranks.Remove(exist);
                        exist.freq = exist.freq + 1;
                        ranks.Add(exist);
                    }
                }
            }

            var lastPosition = ranks.Max(x => x.position);

            for (int k = 1; k <= lastPosition; k++)
            {

                var table = ranks.Where(x => x.position == k)
                    .Select(x => x)
                    .OrderByDescending(x => x.freq)
                    .ToList();

                for (int i = 0; i < table.Count(); i++)
                {
                    var charxList = table
                        .Where(y => y.freq == table[i].freq && !ans.ToString().Contains(y.charx))
                        .Select(x => x.charx)
                        .ToList();

                    if (charxList.Count() == 1 && !ans.ToString().Contains(charxList[0]))
                    {
                        ans.Append(charxList[0]);
                        if (votes[0].Length == ans.ToString().Length)
                        {
                            return ans.ToString();
                        }

                    }
                    else
                    {
                        var nextcharxList = new List<char>();

                        for (int j = table[i].position; j <= lastPosition; j++)
                        {
                            var next = (from r in ranks
                                        where r.position == j
                                        join c in charxList
                                        on r.charx equals c
                                        select r)
                                       .OrderByDescending(x => x.freq)
                                       .ToList();

                            next = next.Where(x => x.freq == next[0].freq).Select(x => x).ToList();

                            if (next.Count() != 0)
                            {

                                nextcharxList = next
                               .Where(y => y.freq == next[0].freq)
                               .Select(x => x.charx)
                               .ToList();
                            }
                            else
                            {
                                nextcharxList = charxList;
                            }

                            if (nextcharxList.Count() == 1 && !ans.ToString().Contains(nextcharxList[0]))
                            {
                                ans.Append(nextcharxList[0]);
                                if (votes[0].Length == ans.ToString().Length)
                                {
                                    return ans.ToString();
                                }
                                break;
                            }

                            if (nextcharxList.Count() > 1 && j == lastPosition)
                            {
                                char? res = nextcharxList
                                    .Where(x => !ans.ToString().Contains(x))
                                    .OrderBy(x => x).Select(x => x)
                                    .FirstOrDefault();

                                if (res != null)
                                {
                                    ans.Append(res);
                                    if (votes[0].Length == ans.ToString().Length)
                                    {
                                        return ans.ToString();
                                    }
                                    break;
                                }
                            }
                            if (next.Count != 0)
                            {
                                charxList = new List<char>();
                                foreach (var xx in next)
                                {
                                    charxList.Add(xx.charx);
                                }
                            }


                        }
                    }
                }
            }
            return ans.ToString();
        }
    }
}

