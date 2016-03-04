using System;
using System.Text.RegularExpressions;

namespace TddDemo
{
    /// <summary>
    /// Project Nummer
    /// </summary>
    public class ProjectNummer
    {
        private string projectnummer;

        /// <summary>
        /// Initialiseert op basis van meegegeven project nummer
        /// </summary>
        /// <param name="projectnummer">Project nummer</param>
        public ProjectNummer(string projectnummer)
        {
            this.projectnummer = projectnummer;
        }

        /// <summary>
        /// Controleert of het projectnummer voldoet aan de ISO234234.
        /// </summary>
        /// <returns>True bij een geldig project nummer, anders false.</returns>
        public bool Check()
        {
            if (!string.IsNullOrEmpty(projectnummer) && 
                projectnummer.Length == 8)
            {
                return true;
            }
            return false;
        }
    }
}