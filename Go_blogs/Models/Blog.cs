using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Go_blogs.Models
{
    public class Blog
    {
        public int BlogId { get; set; } //Otomatis terisi dan sebgai primary key
                                           // (Cara 1  untuk membuat primary keydengan menggunakan nama Id)
        [Required]
        [DisplayName("Judul")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Isinya")]
        public string Content { get; set; }
        [Required]
        [DisplayName("Tanggal Pembuatannya")]
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public User User { get; set; }

    }
}

//Syncronous : sequencial
//Asyncronous : adanya dunia paralel
