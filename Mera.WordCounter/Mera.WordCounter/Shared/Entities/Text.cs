using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Mera.WordCounter.Shared.Entities
{
    /// <summary>
    /// Text Model
    /// </summary>
    public class Text
    {
        /// <summary>
        /// Text Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Text Content
        /// </summary>
        [Required (ErrorMessage = "This field is required.")]
        public string Content { get; set; }
    }
}
