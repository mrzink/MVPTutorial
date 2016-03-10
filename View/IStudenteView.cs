using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ComponentModel.DataAnnotations;
using Common;
namespace View
{
    public interface IStudenteView : IView
    {

        [Required]
        [MaxLength(10)]
        [MinLength(6)]
        string Id { get; set; }

        [Required]
        string Name { get; set; }

        [Required]
        [IntegerValidation()]
        int Age { get; set; }

        [Required]
        string Address { get; set; }

        [Required]
        string Class { get; set; }

        List<StudentModel> ListStudent { set; }


        event EventHandler<EventArgs> AddButtonClick;
        event EventHandler<EventArgs> EditButtonClick;
        event EventHandler<EventArgs> DeleteButtonClick;
        event EventHandler<EventArgs> ResetButtonClick;
        event EventHandler<EventArgs> SaveButtonClick;
        event EventHandler<EventArgs> BackButtonClick;
    }
}
