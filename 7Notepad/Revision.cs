using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Notepad
{
    class Revision
    {
        //Store the version of the revision
        private int revisionNumber;
        //Store the content
        private string content;
        //The delimiter that separates the edits
        private string delimiter;
        private DateTime revisionDate;
        /// <summary>
        /// Creates a new revision of the document 
        /// </summary>
        /// <param name="revisionNumber">version number</param>
        /// <param name="revisionDate">Date and time</param>
        /// <param name="content">Content to be saved</param>
        /// <param name="delimiter">Separates different revisions</param>
        public Revision(int revisionNumber, DateTime revisionDate, string content, string delimiter)
        {
            this.revisionNumber = revisionNumber;
            this.revisionDate = revisionDate;
            this.content = content;
            this.delimiter = delimiter;
        }

        /// <summary>
        /// The document
        /// </summary>
        public string Content
        {
            get { return content; }
        }
        /// <summary>
        /// The date of the revision
        /// </summary>
        public DateTime RevisionDate
        {

            get { return revisionDate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Delimiter
        {
            get { return delimiter; }
            set { delimiter = value; }

        }

        /// <summary>
        /// Gets the revision number
        /// </summary>
        public int RevisionNumber
        {

            get { return revisionNumber; }
        }



    }
}
