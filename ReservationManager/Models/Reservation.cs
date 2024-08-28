using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManager.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string BirthDate { get; set; }

        [MaxLength(50)]
        public string Gender { get; set; }

        [Phone]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [MaxLength(50)]
        public string EmailAddress { get; set; }

        public int NumberGuest { get; set; }

        [MaxLength(200)]
        public string StreetAddress { get; set; }

        [MaxLength(50)]
        public string AptSuite { get; set; }

        [MaxLength(30)]
        public string City { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string ZipCode { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string RoomType { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string RoomFloor { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string RoomNumber { get; set; }

        [Column(TypeName = "float")]
        public float TotalBill { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string PaymentType { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string CardType { get; set; }
        [MaxLength(40)]
        public string CardNumber { get; set; }

        [MaxLength(10)]
        public string CardExp { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string CardCVC { get; set; }

        public DateTime ArrivalTime { get; set; }
        public DateTime LeavingTime { get; set; }
        public bool CheckIn { get; set; }
        public int Breakfast { get; set; }
        public int Lunch { get; set; }
        public int Dinner { get; set; }
        public bool Cleaning { get; set; }
        public bool Towel { get; set; }
        public bool Surprise { get; set; }
        public bool SupplyStatus { get; set; }
        public int FoodBill { get; set; }
    }
}