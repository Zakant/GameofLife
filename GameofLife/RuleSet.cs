using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

namespace GameofLife
{
    public class RuleSet
    {
        protected ZellenStatus[] livingstatus = new ZellenStatus[9];
        protected ZellenStatus[] deadstatus = new ZellenStatus[9];

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string Author { get; protected set; }
        public string Link { get; protected set; }
        public string Guid { get; protected set; }

        public static RuleSet DefaultSet
        {
            get
            {
                return fromXML("<?xml version='1.0' encoding='utf-8' ?>" +
                               "<ruleset>" +
                               "<name>Default RuleSet</name>" +
                               "<description>The Default Rules of the GameOfLife</description>" +
                               "<author>Christian Wieck</author>" +
                               "<link>http://de.wikipedia.org/wiki/Conways_Spiel_des_Lebens</link>" +
                               "<guid>C99D7E0D-8115-4243-B79B-7758309B0022</guid>" +
                               "<rules>" +
                                 "<rule CurrentStatus='Tot' Neighbours-From='3' Neighbours-To='3' NewStatus='Lebt' />" +
                                 "<rule CurrentStatus='Lebt' Neighbours-From='0' Neighbours-To='1' NewStatus='Tot' />" +
                                 "<rule CurrentStatus='Lebt' Neighbours-From='4' Neighbours-To='8' NewStatus='Tot' />" +
                              "</rules>" +
                               "</ruleset>");
            }
        }

        public static RuleSet fromXML(string xml)
        {
            return new RuleSet(xml);
        }
        public static RuleSet fromFile(string file)
        {
            var f = new System.IO.FileInfo(file);
            if (f.Exists)
            {
                using (var r = f.OpenText())
                {
                    return fromXML(r.ReadToEnd());
                }
            }
            throw new System.IO.FileNotFoundException("File was not found");
        }
        protected RuleSet(string xml)
        {
            for (int i = 0; i < 9; i++)
            {
                livingstatus[i] = ZellenStatus.Lebt;
                deadstatus[i] = ZellenStatus.Tot;
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            var root = doc.DocumentElement;
            Name = root.SelectSingleNode("./name").InnerText.Trim();
            Description = root.SelectSingleNode("./description").InnerText.Trim();
            Author = root.SelectSingleNode("./author").InnerText.Trim();
            Link = root.SelectSingleNode("./link").InnerText.Trim();
            Guid = root.SelectSingleNode("./guid").InnerText.Trim();
            var rules = root.SelectSingleNode("./rules");
            foreach (XmlNode rule in rules.SelectNodes("./rule"))
            {
                int lboarder = Int32.Parse(rule.Attributes["Neighbours-From"].Value.Trim());
                int uboarder = Int32.Parse(rule.Attributes["Neighbours-To"].Value.Trim());
                var n = parseZellenStatus(rule.Attributes["NewStatus"].Value.Trim());
                for (int i = lboarder; i <= uboarder; i++)
                {
                    if (rule.Attributes["CurrentStatus"] == null)
                    {
                        livingstatus[i] = n;
                        deadstatus[i] = n;
                    }
                    else
                        if (parseZellenStatus(rule.Attributes["CurrentStatus"].Value.Trim()) == ZellenStatus.Lebt)
                            livingstatus[i] = n;
                        else
                            deadstatus[i] = n;
                }
            }
        }

        public ZellenStatus applyRuleset(ZellenStatus currentstatus, int livingneighbours)
        {
            if (currentstatus == ZellenStatus.Lebt)
            {
                return livingstatus[livingneighbours];
            }
            else
            {
                return deadstatus[livingneighbours];
            }
        }

        protected ZellenStatus parseZellenStatus(string s)
        {
            int i;
            bool b;
            if (Int32.TryParse(s, out i))
            {
                return i == 0 ? ZellenStatus.Lebt : ZellenStatus.Tot;
            }
            else if (Boolean.TryParse(s, out b))
            {
                return b ? ZellenStatus.Lebt : ZellenStatus.Tot;
            }
            else
            {
                switch (s)
                {
                    case "Lebt":
                    case "Living":
                        return ZellenStatus.Lebt;
                    case "Tot":
                    case "Dead":
                        return ZellenStatus.Tot;
                    default:
                        break;
                }
            }
            return ZellenStatus.Tot;
        }

    }
}
