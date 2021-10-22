using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Office.Utils;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Services;
using System.Linq;
using System.Text.RegularExpressions;

namespace BoyArge
{
    //string[] keywords = { "<",">","/","Dashboard", "Title", "DataSources", "SqlDataSource", "Connection", "Query", "Tables", "<Table", "Relation", "KeyColumn", "WITH", "SET", "GO", "DECLARE", "EXECUTE", "NVARCHAR", "FROM", "INTO", "VALUES", "WHERE", "AND" };
    public class CustomSyntaxHighlightService : ISyntaxHighlightService
    {
        #region #parsetokens
        readonly Document document;
        SyntaxHighlightProperties defaultSettings = new SyntaxHighlightProperties() { ForeColor = Color.Brown };
        SyntaxHighlightProperties keywordSettings = new SyntaxHighlightProperties() { ForeColor = Color.Blue };
        SyntaxHighlightProperties keywordSettings1 = new SyntaxHighlightProperties() { ForeColor = Color.Red };
        SyntaxHighlightProperties stringSettings = new SyntaxHighlightProperties() { ForeColor = Color.Black };
        SyntaxHighlightProperties commentSettings = new SyntaxHighlightProperties() { ForeColor = Color.Green };

        string[] comments = new string[]
            {"<!--", "-->"};

        string[] keywords = new string[] 
        { 
            //"version", "encoding", "application", "name", "isnull", "iskey", "value", "=", "</", "/>", "<", ">"};
            "version", "encoding", "application", "value", "=", "</", "/>", "<", ">"};
        //,"Dashboard", "Title", "DataSources", "SqlDataSource", "Connection", "Query", "Tables", "<Table", "Relation", "KeyColumn"
        string[] keywords1 = new string[] {
            "name", "attribute" };


        public CustomSyntaxHighlightService(Document document)
        {
            this.document = document;
        }

        private List<SyntaxHighlightToken> ParseTokens()
        {
            List<SyntaxHighlightToken> tokens = new List<SyntaxHighlightToken>();
            DocumentRange[] ranges = null;

            DocumentRange[] commentRanges = document.FindAll(new Regex("<!--(.*?)-->"));
            for (int j = 0; j < commentRanges.Length; j++)
            {
                if (!IsRangeInTokens(commentRanges[j], tokens))
                    tokens.Add(new SyntaxHighlightToken(commentRanges[j].Start.ToInt(), commentRanges[j].Length, commentSettings));
            }
            DocumentRange[] textRanges = document.FindAll(new Regex(">(.*?)</"));
            for (int j = 0; j < textRanges.Length; j++)
            {
                DocumentRange textRange = document.CreateRange(textRanges[j].Start.ToInt() + 1, textRanges[j].End.ToInt() - textRanges[j].Start.ToInt() - 3);
                if (!IsRangeInTokens(textRange, tokens))
                    tokens.Add(new SyntaxHighlightToken(textRange.Start.ToInt(), textRange.Length, stringSettings));
            }
            //search for comments  
            for (int k = 0; k < comments.Length; k++)
            {
                ranges = document.FindAll(comments[k], SearchOptions.None);

                for (int l = 0; l < ranges.Length; l++)
                {
                    if (!IsRangeInTokens(ranges[l], tokens))
                        tokens.Add(new SyntaxHighlightToken(ranges[l].Start.ToInt(), ranges[l].Length, commentSettings));
                }
            }
            // search for quotation marks
            ranges = document.FindAll("\"", SearchOptions.None);
            for (int i = 0; i < ranges.Length / 2; i++)
            {
                tokens.Add(new SyntaxHighlightToken(ranges[i * 2].Start.ToInt(),
                    ranges[i * 2 + 1].Start.ToInt() - ranges[i * 2].Start.ToInt() + 1, stringSettings));
            }
            // search for keywords
            for (int i = 0; i < keywords.Length; i++)
            {
                ranges = document.FindAll(keywords[i], SearchOptions.None);

                for (int j = 0; j < ranges.Length; j++)
                {
                    if (!IsRangeInTokens(ranges[j], tokens))
                        tokens.Add(new SyntaxHighlightToken(ranges[j].Start.ToInt(), ranges[j].Length, keywordSettings));
                }
            }

            // search for keywords1
            for (int i = 0; i < keywords1.Length; i++)
            {
                ranges = document.FindAll(keywords1[i], SearchOptions.None);

                for (int j = 0; j < ranges.Length; j++)
                {
                    if (!IsRangeInTokens(ranges[j], tokens))
                        tokens.Add(new SyntaxHighlightToken(ranges[j].Start.ToInt(), ranges[j].Length, keywordSettings1));
                }
            }

            // order tokens by their start position
            tokens.Sort(new SyntaxHighlightTokenComparer());
            // fill in gaps in document coverage
            AddPlainTextTokens(tokens);
            return tokens;
        }

        private void AddPlainTextTokens(List<SyntaxHighlightToken> tokens)
        {
            int count = tokens.Count;
            if (count == 0)
            {
                tokens.Add(new SyntaxHighlightToken(0, document.Range.End.ToInt(), defaultSettings));
                return;
            }
            tokens.Insert(0, new SyntaxHighlightToken(0, tokens[0].Start, defaultSettings));
            for (int i = 1; i < count; i++)
            {
                tokens.Insert(i * 2, new SyntaxHighlightToken(tokens[i * 2 - 1].End, tokens[i * 2].Start - tokens[i * 2 - 1].End, defaultSettings));
            }
            tokens.Add(new SyntaxHighlightToken(tokens[count * 2 - 1].End, document.Range.End.ToInt() - tokens[count * 2 - 1].End, defaultSettings));
        }

        private bool IsRangeInTokens(DocumentRange range, List<SyntaxHighlightToken> tokens)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                if (range.Start.ToInt() >= tokens[i].Start && range.End.ToInt() <= tokens[i].End)
                    return true;
            }
            return false;
        }
        #endregion #parsetokens

        #region #ISyntaxHighlightServiceMembers
        public void ForceExecute()
        {
            Execute();
        }
        public void Execute()
        {
            document.ApplySyntaxHighlight(ParseTokens());
        }
        #endregion #ISyntaxHighlightServiceMembers
    }
    #region #SyntaxHighlightTokenComparer
    public class SyntaxHighlightTokenComparer : IComparer<SyntaxHighlightToken>
    {
        public int Compare(SyntaxHighlightToken x, SyntaxHighlightToken y)
        {
            return x.Start - y.Start;
        }
    }
    #endregion #SyntaxHighlightTokenComparer

}