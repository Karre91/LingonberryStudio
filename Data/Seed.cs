using LingonberryStudio.Models;
using LingonberryStudio.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace LingonberryStudio.Data
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LingonberryDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LingonberryDbContext>>()))
            {

                if (context.Adverts.Any())
                {
                    return;   // DB has been seeded
                }

                context.Adverts.AddRange(
                    // ALL OFFERING
                    new Advert()
                    {
                        TimeCreated = DateTime.Today,
                        FirstName = "Karin",
                        LastName = "Eurenius",
                        Email = "kleurenius@gmail.com",
                        PhoneNumber = 0707310791,
                        Offering = true,
                        Looking = false,
                        City = "LONDON",
                        Area = "EAST",
                        WorkPlaces = new()
                        {
                            ArtStudio = true,
							Description = "Description",
							ImgUrl = "seedImg/artOffering.jpg"
						},
                        Amenities = new()
                        {
                            Parking = false,
                            AirCon = true,
                            Kitchen = false,
                            NaturalLight = true,
                            AcousticTreatment = false,
                            RunningWater = true,
                            Storage = true,
                            Other = "Changing rooms"
                        },
                        Budgets = new()
                        {
                            Month = true,
                            Price = 80,
                        },
                        Measurements = new()
                        {
                            Meters = true,
                            Number = 40,
                        },
                        DatesAndTimes = new()
                        {
                            StartDate = new(2023, 02, 14),
                            EndDate = new(2024, 02, 14),
                            OpeningTime = new(2023, 02, 14, 08, 30, 00),
                            ClosingTime = new(2024, 02, 14, 17, 30, 00),
                            Days = new()
                            {
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = false,
                                Sunday = false
                            },
                        },
                        Artist = "KarinSjunger",
                        SocialMedia = "@instagram KarinSjunger"
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 01),
                        FirstName = "Allan",
                        LastName = "Banan",
                        Email = "allan4twin@gmail.com",
                        PhoneNumber = 123456789,
                        Offering = true,
                        City = "STOCKHOLM",
                        Area = "SOLNA",
                        WorkPlaces = new()
                        {
                            PhotoStudio = true,
							Description = "Description",
							ImgUrl = "seedImg/photoOffering.jpg"
						},
                        Amenities = new()
                        {
                            Parking = false,
                            AirCon = false,
                            Kitchen = false,
                            NaturalLight = false,
                            AcousticTreatment = true,
                            RunningWater = true,
                            Storage = true,
                            Other = "Tripod"
                        },
                        Budgets = new()
                        {
                            Month = true,
                            Price = 100,
                        },
                        Measurements = new()
                        {
                            Feet = true,
                            Number = 90,
                        },
                        DatesAndTimes = new()
                        {
                            StartDate = new(2023, 02, 01),
                            EndDate = new(2023, 03, 14),
                            OpeningTime = new(2023, 02, 14, 12, 30, 00),
                            ClosingTime = new(2024, 02, 14, 21, 30, 00),
                            Days = new()
                            {
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = true,
                                Sunday = true
                            },
                        },
                        Artist = null,
                        SocialMedia = null
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 02),
                        FirstName = "Josefin",
                        LastName = "Unefäldt",
                        Email = "jossebosse@gmail.com",
                        PhoneNumber = 123456789,
                        Offering = true,
                        City = "LONDON",
                        Area = "HACKNEY",
                        WorkPlaces = new()
                        {
                            CeramicsStudio = true,
							Description = "Description",
							ImgUrl = "seedImg/ceramicsOffering.jpg"
						},
                        Amenities = new()
                        {
                            Parking = false,
                            AirCon = false,
                            Kitchen = false,
                            NaturalLight = false,
                            AcousticTreatment = true,
                            RunningWater = true,
                            Storage = true,
                            Other = "Oven"
                        },
                        Budgets = new()
                        {
                            Month = true,
                            Price = 100,
                        },
                        Measurements = new()
                        {
                            Feet = true,
                            Number = 90,
                        },
                        DatesAndTimes = new()
                        {
                            StartDate = new(2023, 02, 01),
                            EndDate = new(2023, 06, 30),
                            OpeningTime = new(2023, 02, 14, 08, 00, 00),
                            ClosingTime = new(2024, 02, 14, 16, 30, 00),
                            Days = new()
                            {
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = false,
                                Friday = false,
                                Saturday = false,
                                Sunday = true
                            },
                        },
                        Artist = null,
                        SocialMedia = null
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 03),
                        FirstName = "Kalle",
                        LastName = "Josefsson",
                        Email = "test@gmail.com",
                        PhoneNumber = 123456789,
                        Offering = true,
                        City = "GOTHENBURG",
                        Area = "MOLNDAL",
                        WorkPlaces = new()
                        {
                            DanceRehersalStudio = true,
							Description = "Description",
							ImgUrl = "seedImg/danceOffering.jpg"
						},
                        Amenities = new()
                        {
                            Parking = true,
                            AirCon = true,
                            Kitchen = true,
                            NaturalLight = false,
                            AcousticTreatment = false,
                            RunningWater = true,
                            Storage = true,
                            Other = "Lights"
                        },
                        Budgets = new()
                        {
                            Month = true,
                            Price = 150,
                        },
                        Measurements = new()
                        {
                            Feet = true,
                            Number = 120,
                        },
                        DatesAndTimes = new()
                        {
                            StartDate = new(2023, 02, 01),
                            EndDate = new(2023, 06, 01),
                            OpeningTime = new(2023, 02, 14, 08, 00, 00),
                            ClosingTime = new(2024, 02, 14, 16, 30, 00),
                            Days = new()
                            {
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = true,
                                Sunday = true
                            },
                        },
                        Artist = null,
                        SocialMedia = null
                    }
                    ,
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 04),
                        FirstName = "Sara",
                        LastName = "Andersson",
                        Email = "test@gmail.com",
                        PhoneNumber = 123456789,
                        Offering = true,
                        City = "CARDIFF",
                        Area = "CENTER",
                        WorkPlaces = new()
                        {
                            MusicStudio = true,
							Description = "Description",
							ImgUrl = "seedImg/musicOffering.jpg"
						},
                        Amenities = new()
                        {
                            Parking = false,
                            AirCon = false,
                            Kitchen = false,
                            NaturalLight = false,
                            AcousticTreatment = true,
                            RunningWater = true,
                            Storage = true,
                            Other = "Drumset"
                        },
                        Budgets = new()
                        {
                            Week = true,
                            Price = 30,
                        },
                        Measurements = new()
                        {
                            Meters = true,
                            Number = 80,
                        },
                        DatesAndTimes = new()
                        {
                            StartDate = new(2023, 05, 01),
                            EndDate = new(2024, 05, 01),
                            OpeningTime = new(2023, 05, 01, 08, 00, 00),
                            ClosingTime = new(2024, 05, 01, 22, 30, 00),
                            Days = new()
                            {
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = true,
                                Sunday = true
                            },
                        },
                        Artist = "Madonna",
                        SocialMedia = null
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 06),
                        FirstName = "Marie",
                        LastName = "Jansson",
                        Email = "test@gmail.com",
                        PhoneNumber = 123456789,
                        Offering = true,
                        City = "BRISTOL",
                        Area = "",
                        WorkPlaces = new()
                        {
                            PaintingWorkshop = true,
							Description = "Description",
							ImgUrl = "seedImg/paintOffering.jpg"
						},
                        Amenities = new()
                        {
                            Parking = true,
                            AirCon = true,
                            Kitchen = true,
                            NaturalLight = true,
                            AcousticTreatment = false,
                            RunningWater = true,
                            Storage = true,
                            Other = ""
                        },
                        Budgets = new()
                        {
                            Month = true,
                            Price = 50,
                        },
                        Measurements = new()
                        {
                            Feet = true,
                            Number = 30,
                        },
                        DatesAndTimes = new()
                        {
                            StartDate = new(2023, 02, 25),
                            EndDate = new(2023, 06, 01),
                            OpeningTime = new(2023, 02, 14, 08, 00, 00),
                            ClosingTime = new(2024, 02, 14, 16, 30, 00),
                            Days = new()
                            {
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = false,
                                Friday = true,
                                Saturday = true,
                                Sunday = true
                            },
                        },
                        Artist = null,
                        SocialMedia = null
                    }
                    ,
                    // ALL LOOKING
                    new Advert()
                    {
                        TimeCreated = DateTime.Today,
                        FirstName = "Karin",
                        LastName = "Eurenius",
                        Email = "kleurenius@gmail.com",
                        PhoneNumber = 0707310791,
                        Looking = true,
                        City = "LONDON",
                        Area = "EAST",
                        WorkPlaces = new()
                        {
                            PhotoStudio = true,
							Description = "Description",
							ImgUrl = "seedImg/photoLooking.jpg"
						},
                        Amenities = new()
                        {
                            Parking = false,
                            AirCon = true,
                            Kitchen = false,
                            NaturalLight = true,
                            AcousticTreatment = false,
                            RunningWater = true,
                            Storage = true,
                            Other = "Changing rooms"
                        },
                        Budgets = new()
                        {
                            Month = true,
                            Price = 80,
                        },
                        Measurements = new()
                        {
                            Feet = true,
                            Number = 40,
                        },
                        DatesAndTimes = new()
                        {
                            StartDate = new(2023, 02, 14),
                            EndDate = new(2024, 02, 14),
                            OpeningTime = new(2023, 02, 14, 08, 30, 00),
                            ClosingTime = new(2024, 02, 14, 17, 30, 00),
                            Days = new()
                            {
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = false,
                                Sunday = false
                            },
                        },
                        Artist = "KarinSjunger",
                        SocialMedia = "@instagram KarinSjunger"
                    }
                    ,
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 01),
                        FirstName = "Allan",
                        LastName = "Banan",
                        Email = "allan4twin@gmail.com",
                        PhoneNumber = 123456789,
                        Looking = true,
                        City = "STOCKHOLM",
                        Area = "SOLNA",
                        WorkPlaces = new()
                        {
                            ArtStudio = true,
							Description = "Description",
							ImgUrl = "seedImg/artLooking.jpg"
						},
                        Amenities = new()
                        {
                            Parking = false,
                            AirCon = false,
                            Kitchen = false,
                            NaturalLight = false,
                            AcousticTreatment = true,
                            RunningWater = true,
                            Storage = true,
                            Other = "Tripod"
                        },
                        Budgets = new()
                        {
                            Month = true,
                            Price = 100,
                        },
                        Measurements = new()
                        {
                            Feet = true,
                            Number = 90,
                        },
                        DatesAndTimes = new()
                        {
                            StartDate = new(2023, 02, 01),
                            EndDate = new(2023, 03, 14),
                            OpeningTime = new(2023, 02, 14, 12, 30, 00),
                            ClosingTime = new(2024, 02, 14, 21, 30, 00),
                            Days = new()
                            {
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = true,
                                Sunday = true
                            },
                        },
                        Artist = null,
                        SocialMedia = null
                    }
                    ,
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 02),
                        FirstName = "Josefin",
                        LastName = "Unefäldt",
                        Email = "jossebosse@gmail.com",
                        PhoneNumber = 123456789,
                        Looking = true,
                        City = "LONDON",
                        Area = "HACKNEY",
                        WorkPlaces = new()
                        {
                            CeramicsStudio = true,
							Description = "Description",
							ImgUrl = "seedImg/ceramicsLooking.jpg"
						},
                        Amenities = new()
                        {
                            Parking = false,
                            AirCon = false,
                            Kitchen = false,
                            NaturalLight = false,
                            AcousticTreatment = true,
                            RunningWater = true,
                            Storage = true,
                            Other = "Oven"
                        },
                        Budgets = new()
                        {
                            Month = true,
                            Price = 100,
                        },
                        Measurements = new()
                        {
                            Feet = true,
                            Number = 90,
                        },
                        DatesAndTimes = new()
                        {
                            StartDate = new(2023, 02, 01),
                            EndDate = new(2023, 06, 30),
                            OpeningTime = new(2023, 02, 14, 08, 00, 00),
                            ClosingTime = new(2024, 02, 14, 16, 30, 00),
                            Days = new()
                            {
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = false,
                                Friday = false,
                                Saturday = false,
                                Sunday = true
                            },
                        },
                        Artist = null,
                        SocialMedia = null
                    }
                    ,
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 03),
                        FirstName = "Kalle",
                        LastName = "Josefsson",
                        Email = "test@gmail.com",
                        PhoneNumber = 123456789,
                        Looking = true,
                        City = "GOTHENBURG",
                        Area = "MOLNDAL",
                        WorkPlaces = new()
                        {
                            DanceRehersalStudio = true,
							Description = "Description",
							ImgUrl = "seedImg/danceLooking.jpg"
						},
                        Amenities = new()
                        {
                            Parking = true,
                            AirCon = true,
                            Kitchen = true,
                            NaturalLight = false,
                            AcousticTreatment = false,
                            RunningWater = true,
                            Storage = true,
                            Other = "Lights"
                        },
                        Budgets = new()
                        {
                            Month = true,
                            Price = 150,
                        },
                        Measurements = new()
                        {
                            Meters = true,
                            Number = 120,
                        },
                        DatesAndTimes = new()
                        {
                            StartDate = new(2023, 02, 01),
                            EndDate = new(2023, 06, 01),
                            OpeningTime = new(2023, 02, 14, 08, 00, 00),
                            ClosingTime = new(2024, 02, 14, 16, 30, 00),
                            Days = new()
                            {
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = true,
                                Sunday = true
                            },
                        },
                        Artist = null,
                        SocialMedia = null
                    }
                    ,
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 04),
                        FirstName = "Sara",
                        LastName = "Andersson",
                        Email = "test@gmail.com",
                        PhoneNumber = 123456789,
                        Looking = true,
                        City = "CARDIFF",
                        Area = "CENTER",
                        WorkPlaces = new()
                        {
                            MusicStudio = true,
							Description = "Description",
							ImgUrl = "seedImg/musicLooking.jpg"
						},
                        Amenities = new()
                        {
                            Parking = false,
                            AirCon = false,
                            Kitchen = false,
                            NaturalLight = false,
                            AcousticTreatment = true,
                            RunningWater = true,
                            Storage = true,
                            Other = "Drumset"
                        },
                        Budgets = new()
                        {
                            Week = true,
                            Price = 20,
                        },
                        Measurements = new()
                        {
                            Meters = true,
                            Number = 80,
                        },
                        DatesAndTimes = new()
                        {
                            StartDate = new(2023, 05, 01),
                            EndDate = new(2024, 05, 01),
                            OpeningTime = new(2023, 05, 01, 08, 00, 00),
                            ClosingTime = new(2024, 05, 01, 22, 30, 00),
                            Days = new()
                            {
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = true,
                                Sunday = true
                            },
                        },
                        Artist = "Madonna",
                        SocialMedia = null
                    }
                    ,
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 06),
                        FirstName = "Marie",
                        LastName = "Jansson",
                        Email = "test@gmail.com",
                        PhoneNumber = 123456789,
                        Looking = true,
                        City = "BRISTOL",
                        Area = "",
                        WorkPlaces = new()
                        {
                            PaintingWorkshop = true,
							Description = "Description",
							ImgUrl = "seedImg/paintLooking.jpg"
						},
                        Amenities = new()
                        {
                            Parking = true,
                            AirCon = true,
                            Kitchen = true,
                            NaturalLight = true,
                            AcousticTreatment = false,
                            RunningWater = true,
                            Storage = true,
                            Other = ""
                        },
                        Budgets = new()
                        {
                            Month = true,
                            Price = 50,
                        },
                        Measurements = new()
                        {
                            Feet = true,
                            Number = 30,
                        },
                        DatesAndTimes = new()
                        {
                            StartDate = new(2023, 02, 25),
                            EndDate = new(2023, 06, 01),
                            OpeningTime = new(2023, 02, 14, 08, 00, 00),
                            ClosingTime = new(2024, 02, 14, 16, 30, 00),
                            Days = new()
                            {
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = false,
                                Friday = true,
                                Saturday = true,
                                Sunday = true
                            },
                        },
                        Artist = null,
                        SocialMedia = null
                    }
                    ,
                    // ALL OTHERS
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 04),
                        FirstName = "Sara",
                        LastName = "Andersson",
                        Email = "test@gmail.com",
                        PhoneNumber = 123456789,
                        Offering = true,
                        City = "CARDIFF",
                        Area = "CENTER",
                        WorkPlaces = new()
                        {
                            OtherStudio = "Yoga Studio",
							Description = "Description",
							ImgUrl = "seedImg/yogaOffering.jpg"
						},
                        Amenities = new()
                        {
                            Parking = false,
                            AirCon = true,
                            Kitchen = false,
                            NaturalLight = false,
                            AcousticTreatment = false,
                            RunningWater = true,
                            Storage = true,
                            Other = "Yoga mats"
                        },
                        Budgets = new()
                        {
                            Month = true,
                            Price = 200,
                        },
                        Measurements = new()
                        {
                            Meters = true,
                            Number = 80,
                        },
                        DatesAndTimes = new()
                        {
                            StartDate = new(2023, 05, 01),
                            EndDate = new(2024, 05, 01),
                            OpeningTime = new(2023, 05, 01, 08, 00, 00),
                            ClosingTime = new(2024, 05, 01, 22, 30, 00),
                            Days = new()
                            {
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = true,
                                Sunday = true
                            },
                        },
                        Artist = null,
                        SocialMedia = null
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 04),
                        FirstName = "Sara",
                        LastName = "Andersson",
                        Email = "test@gmail.com",
                        PhoneNumber = 123456789,
                        Offering = true,
                        City = "LONDON",
                        Area = "CENTER",
                        WorkPlaces = new()
                        {
                            OtherStudio = "Darkroom",
							Description = "Description",
							ImgUrl = "seedImg/darkroom.jpg"
						},
                        Amenities = new()
                        {
                            Parking = false,
                            AirCon = false,
                            Kitchen = false,
                            NaturalLight = false,
                            AcousticTreatment = false,
                            RunningWater = true,
                            Storage = true,
                            Other = "Photo cutters"
                        },
                        Budgets = new()
                        {
                            Month = true,
                            Price = 200,
                        },
                        Measurements = new()
                        {
                            Meters = true,
                            Number = 40,
                        },
                        DatesAndTimes = new()
                        {
                            StartDate = new(2023, 05, 01),
                            EndDate = new(2024, 05, 01),
                            OpeningTime = new(2023, 05, 01, 12, 00, 00),
                            ClosingTime = new(2024, 05, 01, 14, 30, 00),
                            Days = new()
                            {
                                Monday = true,
                                Tuesday = true,
                                Wednesday = false,
                                Thursday = false,
                                Friday = false,
                                Saturday = false,
                                Sunday = false
                            },
                        },
                        Artist = null,
                        SocialMedia = null
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 04),
                        FirstName = "Sara",
                        LastName = "Andersson",
                        Email = "test@gmail.com",
                        PhoneNumber = 123456789,
                        Looking = true,
                        City = "LONDON",
                        Area = "SOUTH",
                        WorkPlaces = new()
                        {
                            OtherStudio = "Film Studio",
                            Description = "Description",
                            ImgUrl = "seedImg/film.jpg"
                        },
                        Amenities = new()
                        {
                            Parking = false,
                            AirCon = false,
                            Kitchen = false,
                            NaturalLight = false,
                            AcousticTreatment = true,
                            RunningWater = true,
                            Storage = true,
                            Other = ""
                        },
                        Budgets = new()
                        {
                            Month = true,
                            Price = 200,
                        },
                        Measurements = new()
                        {
                            Meters = true,
                            Number = 80,
                        },
                        DatesAndTimes = new()
                        {
                            StartDate = new(),
                            EndDate = new(),
                            OpeningTime = new(),
                            ClosingTime = new(),
                            Days = new()
                            {
                                Monday = false,
                                Tuesday = false,
                                Wednesday = false,
                                Thursday = false,
                                Friday = false,
                                Saturday = false,
                                Sunday = false
                            },
                        },
                        Artist = null,
                        SocialMedia = null
                    }
                    );

                context.SaveChanges();
            }
        }

    }
}


