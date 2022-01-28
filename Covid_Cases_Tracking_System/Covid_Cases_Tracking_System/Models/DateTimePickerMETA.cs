using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Covid_Cases_Tracking_System.Models
{
    public class DateTimePickerMETAData
    {
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Birthday { get; set; }
    }
    [MetadataType(typeof(DateTimePickerMETAData))]
    public partial class People
    {

    }
}