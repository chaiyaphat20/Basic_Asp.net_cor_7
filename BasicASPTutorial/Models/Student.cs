﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BasicASPTutorial.Models
{
    public class Student
    {
        [Key]  //primaryKey
        public int Id { get; set; }
        [Required]  //none null
        [DisplayName("ชื่อนักเรียน")]
        public string Name { get; set; }
        [DisplayName("คะแนนสอบ")]
        [Range(0,100)]
        public int Score { get; set; }
    }
}
