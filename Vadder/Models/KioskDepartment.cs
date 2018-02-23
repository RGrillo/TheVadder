using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vadder.Models
{
    public class KioskDepartment
    {
        [Key]
        public int KdId { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        [MaxLength(100)]
        public string KdName { get; set; }

        public int KioskId { get; set; }

        [MaxLength(100)]
        public string KdCreateBy { get; set; }

        [MaxLength(100)]
        public string KdModifyBy { get; set; }

        public DateTime? KdCreateUTC { get; set; }

        public DateTime? KdModifyUTC { get; set; }



        public virtual IEnumerable<RegisterViewModel> RegisterViewModels { get; set; }
    }
}