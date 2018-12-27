using System;
using System.ComponentModel.DataAnnotations;
using TimeManager.Extensions;

namespace TimeManager.Model
{
    public class AbsenceValidation
    {
        [Required(ErrorMessage = "Abwesend von darf nicht leer sein")]
        [RegularExpression(@"^(\d{2})\.(\d{2})\.(\d{4})$", ErrorMessage = "Die Eingabe muss in folgendem Format sein: dd.MM.yyyy")]
        public string AbsenceDateFrom { get; set; }

        [Required(ErrorMessage = "Abwesend bis darf nicht leer sein")]
        [RegularExpression(@"^(\d{2})\.(\d{2})\.(\d{4})$", ErrorMessage = "Die Eingabe muss in folgendem Format sein: dd.MM.yyyy")]
        public string AbsenceDateTo { get; set; }

        public bool FullDay { get; set; }

        [RequiredIf(mustBeTrueProperty = "FullDay", ErrorMessage = "Zeit von darf nicht leer sein")]
        [RegularExpression(@"^(\d{2})\:(\d{2})$", ErrorMessage = "Die Eingabe muss in folgendem Format sein: HH:mm")]
        public string AbsenceTimeFrom { get; set; }

        [RequiredIf(mustBeTrueProperty = "FullDay", ErrorMessage = "Zeit von darf nicht leer sein")]
        [RegularExpression(@"^(\d{2})\:(\d{2})$", ErrorMessage = "Die Eingabe muss in folgendem Format sein: HH:mm")]
        public string AbsenceTimeTo { get; set; }

        [Required(ErrorMessage = "Bitte wählen Sie einen der Gründe aus")]
        public string Reason { get; set; }

        [RequiredIf(mustNotBeEmptyProperty = "Reason", ErrorMessage = "Bitte geben sie einen anderen Grund an")]
        public string OtherReason { get; set; }

        public bool Approved { get; set; }
    }
}