﻿using Online_Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Exam.Models
{
    public partial class Exam
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Exam_id { get; set; }

        [Required]
        //  [ForeignKey("Userdata")]
        public string Adminstration_Email { get; set; }

        [Required]
        public string Exam_title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Start_time { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan Duration { get; set; }

        public bool IS_shuffle_Q { get; set; }

        public bool IS_shuffle_A { get; set; }
        [ForeignKey("Adminstration_Email")]
        public virtual Users AdminstrationEmailNavigation { get; set; } = null!;

        public virtual ICollection<Questions> Questions { get; set; } = new List<Questions>();

    }
}
