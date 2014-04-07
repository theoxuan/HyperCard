﻿using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CONVERTER
{
    public class LoadData
    {
        public List<Card> LoadDatabase(string xmlpath)
        {
            List<Card> list = new List<Card>();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlpath);
            XmlElement xmlElement = xmlDocument["cards"];
            foreach (XmlNode xmlNode in xmlElement.ChildNodes)
            {
                Card card = new Card();
                card.ID = xmlNode.Attributes["id"].Value.ToString();
                card.zID = xmlNode.Attributes["zid"].Value.ToString();
                card.Var = xmlNode.Attributes["var"].Value.ToString();
                card.Name = xmlNode.Attributes["name"].Value.ToString();
                card.zName = xmlNode.Attributes["zname"].Value.ToString();
                card.Set = xmlNode.Attributes["set"].Value.ToString();
                card.SetCode = xmlNode.Attributes["setcode"].Value.ToString();
                card.Color = xmlNode.Attributes["color"].Value.ToString();
                card.ColorCode = xmlNode.Attributes["colorcode"].Value.ToString();
                card.Cost = xmlNode.Attributes["cost"].Value.ToString();
                card.CMC = xmlNode.Attributes["cmc"].Value.ToString();
                card.Type = xmlNode.Attributes["type"].Value.ToString();
                card.zType = xmlNode.Attributes["ztype"].Value.ToString();
                card.TypeCode = xmlNode.Attributes["typecode"].Value.ToString();
                card.Mana = xmlNode.Attributes["mana"].Value.ToString();
                card.Pow = xmlNode.Attributes["pow"].Value.ToString();
                card.Tgh = xmlNode.Attributes["tgh"].Value.ToString();
                card.Loyalty = xmlNode.Attributes["loyalty"].Value.ToString();
                card.Text = xmlNode.Attributes["text"].Value.ToString();
                card.zText = xmlNode.Attributes["ztext"].Value.ToString();
                card.Flavor = xmlNode.Attributes["flavor"].Value.ToString();
                card.zFlavor = xmlNode.Attributes["zflavor"].Value.ToString();
                card.Rarity = xmlNode.Attributes["rarity"].Value.ToString();
                card.RarityCode = xmlNode.Attributes["raritycode"].Value.ToString();
                card.Artist = xmlNode.Attributes["artist"].Value.ToString();
                card.Number = xmlNode.Attributes["number"].Value.ToString();
                card.Rulings = xmlNode.Attributes["rulings"].Value.ToString();
                card.cPic = new List<string>();
                card.cPic = GetManaIcon(card);
                card.tPic = new List<string>();
                foreach (var t in card.TypeCode)
                {
                    card.tPic.Add(string.Format("/Resources/type_{0}.png", t.ToString().ToLower()));
                }
                list.Add(card);
            }
            return list;
        }

        private List<string> GetManaIcon(Card card)
        {
            char[] separator = new char[] { '{', '}' };
            string[] array = new string[] { "" };
            if (card.Cost != null)
            {
                array = card.Cost.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            }
            List<string> list = new List<string>();
            string[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                string mana = array2[i];
                try
                {
                    if (mana != "|")
                    {
                        list.Add(String.Format("/Resources/mana_{0}.png", mana.ToLower()));
                    }
                    else
                    {
                        list.Add("/Resources/mana_sep.png");
                    }
                }
                catch (Exception ex)
                {
                    break;
                }
            }
            return list;
        }
    }
}
