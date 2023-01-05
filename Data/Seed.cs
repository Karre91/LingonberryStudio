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
                        OfferingLooking = "Offering",
                        WorkspaceDescription = "Photo Studio",
                        City = "LONDON",
                        Area = "EAST",
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
                            MonthOrWeek = "Month",
                            Price = 80,
                        },
                        Measurements = new()
                        {
                            FeetOrMeters = "Square metres",
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
                        SocialMedia = "@instagram KarinSjunger",
                        Description = new()
                        {
                            ImgUrl = "seedImg/photoOffering.jpg",
                            Desc = "Lorem ipsum dolor sit amet, volumus omittantur reformidans sit id, in homero ridens duo, verterem singulis pro no. Vim offendit tractatos eu. Ea magna audiam pro. Eu has alii adversarium. Ignota necessitatibus eu pri, vix id eius platonem.\r\n\r\nMea vidit epicuri intellegam an, elit molestie an pro. Vim aeterno indoctum ut, vel putent lucilius mandamus ei. Ex zril dolorum voluptatum eam. Lorem graece his te, ad diam congue eos. Primis vituperata necessitatibus vix an."
                        }
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 01),
                        FirstName = "Allan",
                        LastName = "Banan",
                        Email = "allan4twin@gmail.com",
                        PhoneNumber = 123456789,
                        OfferingLooking = "Offering",
                        WorkspaceDescription = "Art Studio",
                        City = "STOCKHOLM",
                        Area = "SOLNA",
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
                            MonthOrWeek = "Month",
                            Price = 100,
                        },
                        Measurements = new()
                        {
                            FeetOrMeters = "Square feet",
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
                        SocialMedia = null,
                        Description = new()
                        {
                            ImgUrl = "seedImg/artOffering.jpg",
                            Desc = "Lorem ipsum dolor sit amet, volumus omittantur reformidans sit id, in homero ridens duo, verterem singulis pro no. Vim offendit tractatos eu. Ea magna audiam pro. Eu has alii adversarium. Ignota necessitatibus eu pri, vix id eius platonem.\r\n\r\nMea vidit epicuri intellegam an, elit molestie an pro. Vim aeterno indoctum ut, vel putent lucilius mandamus ei. Ex zril dolorum voluptatum eam. Lorem graece his te, ad diam congue eos. Primis vituperata necessitatibus vix an."
                        }
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 02),
                        FirstName = "Josefin",
                        LastName = "Unefäldt",
                        Email = "jossebosse@gmail.com",
                        PhoneNumber = 123456789,
                        OfferingLooking = "Offering",
                        WorkspaceDescription = "Ceramics Studio",
                        City = "LONDON",
                        Area = "HACKNEY",
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
                            MonthOrWeek = "Month",
                            Price = 100,
                        },
                        Measurements = new()
                        {
                            FeetOrMeters = "Square feet",
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
                        SocialMedia = null,
                        Description = new()
                        {
                            ImgUrl = "seedImg/ceramicsOffering.jpg",
                            Desc = "Lorem ipsum dolor sit amet, volumus omittantur reformidans sit id, in homero ridens duo, verterem singulis pro no. Vim offendit tractatos eu. Ea magna audiam pro. Eu has alii adversarium. Ignota necessitatibus eu pri, vix id eius platonem.\r\n\r\nMea vidit epicuri intellegam an, elit molestie an pro. Vim aeterno indoctum ut, vel putent lucilius mandamus ei. Ex zril dolorum voluptatum eam. Lorem graece his te, ad diam congue eos. Primis vituperata necessitatibus vix an."
                        }
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 03),
                        FirstName = "Kalle",
                        LastName = "Josefsson",
                        Email = "test@gmail.com",
                        PhoneNumber = 123456789,
                        OfferingLooking = "Offering",
                        WorkspaceDescription = "Dance Rehersal Studio",
                        City = "GOTHENBURG",
                        Area = "MOLNDAL",
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
                            MonthOrWeek = "Month",
                            Price = 150,
                        },
                        Measurements = new()
                        {
                            FeetOrMeters = "Square meters",
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
                        SocialMedia = null,
                        Description = new()
                        {
                            ImgUrl = "seedImg/danceOffering.jpg",
                            Desc = "Lorem ipsum dolor sit amet, volumus omittantur reformidans sit id, in homero ridens duo, verterem singulis pro no. Vim offendit tractatos eu. Ea magna audiam pro. Eu has alii adversarium. Ignota necessitatibus eu pri, vix id eius platonem.\r\n\r\nMea vidit epicuri intellegam an, elit molestie an pro. Vim aeterno indoctum ut, vel putent lucilius mandamus ei. Ex zril dolorum voluptatum eam. Lorem graece his te, ad diam congue eos. Primis vituperata necessitatibus vix an."
                        }
                    }
                    ,
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 04),
                        FirstName = "Sara",
                        LastName = "Andersson",
                        Email = "test@gmail.com",
                        PhoneNumber = 123456789,
                        OfferingLooking = "Offering",
                        WorkspaceDescription = "Music Studio",
                        City = "CARDIFF",
                        Area = "CENTER",
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
                            MonthOrWeek = "Month",
                            Price = 200,
                        },
                        Measurements = new()
                        {
                            FeetOrMeters = "Square meters",
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
                        SocialMedia = null,
                        Description = new()
                        {
                            ImgUrl = "seedImg/musicOffering.jpg",
                            Desc = "Lorem ipsum dolor sit amet, volumus omittantur reformidans sit id, in homero ridens duo, verterem singulis pro no. Vim offendit tractatos eu. Ea magna audiam pro. Eu has alii adversarium. Ignota necessitatibus eu pri, vix id eius platonem.\r\n\r\nMea vidit epicuri intellegam an, elit molestie an pro. Vim aeterno indoctum ut, vel putent lucilius mandamus ei. Ex zril dolorum voluptatum eam. Lorem graece his te, ad diam congue eos. Primis vituperata necessitatibus vix an."
                        }
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 06),
                        FirstName = "Marie",
                        LastName = "Jansson",
                        Email = "test@gmail.com",
                        PhoneNumber = 123456789,
                        OfferingLooking = "Offering",
                        WorkspaceDescription = "Paint Studio",
                        City = "BRISTOL",
                        Area = "",
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
                            MonthOrWeek = "Month",
                            Price = 50,
                        },
                        Measurements = new()
                        {
                            FeetOrMeters = "Square feet",
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
                        SocialMedia = null,
                        Description = new()
                        {
                            ImgUrl = "seedImg/paintOffering.jpg",
                            Desc = "Lorem ipsum dolor sit amet, volumus omittantur reformidans sit id, in homero ridens duo, verterem singulis pro no. Vim offendit tractatos eu. Ea magna audiam pro. Eu has alii adversarium. Ignota necessitatibus eu pri, vix id eius platonem.\r\n\r\nMea vidit epicuri intellegam an, elit molestie an pro. Vim aeterno indoctum ut, vel putent lucilius mandamus ei. Ex zril dolorum voluptatum eam. Lorem graece his te, ad diam congue eos. Primis vituperata necessitatibus vix an."
                        }
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
                        OfferingLooking = "Looking",
                        WorkspaceDescription = "Photo Studio",
                        City = "LONDON",
                        Area = "EAST",
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
                            MonthOrWeek = "Month",
                            Price = 80,
                        },
                        Measurements = new()
                        {
                            FeetOrMeters = "Square metres",
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
                        SocialMedia = "@instagram KarinSjunger",
                        Description = new()
                        {
                            ImgUrl = "seedImg/photoLooking.jpg",
                            Desc = "Lorem ipsum dolor sit amet, volumus omittantur reformidans sit id, in homero ridens duo, verterem singulis pro no. Vim offendit tractatos eu. Ea magna audiam pro. Eu has alii adversarium. Ignota necessitatibus eu pri, vix id eius platonem.\r\n\r\nMea vidit epicuri intellegam an, elit molestie an pro. Vim aeterno indoctum ut, vel putent lucilius mandamus ei. Ex zril dolorum voluptatum eam. Lorem graece his te, ad diam congue eos. Primis vituperata necessitatibus vix an."
                        }
                    }
                    ,
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 01),
                        FirstName = "Allan",
                        LastName = "Banan",
                        Email = "allan4twin@gmail.com",
                        PhoneNumber = 123456789,
                        OfferingLooking = "Looking",
                        WorkspaceDescription = "Art Studio",
                        City = "STOCKHOLM",
                        Area = "SOLNA",
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
                            MonthOrWeek = "Month",
                            Price = 100,
                        },
                        Measurements = new()
                        {
                            FeetOrMeters = "Square feet",
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
                        SocialMedia = null,
                        Description = new()
                        {
                            ImgUrl = "seedImg/artLooking.jpg",
                            Desc = "Lorem ipsum dolor sit amet, volumus omittantur reformidans sit id, in homero ridens duo, verterem singulis pro no. Vim offendit tractatos eu. Ea magna audiam pro. Eu has alii adversarium. Ignota necessitatibus eu pri, vix id eius platonem.\r\n\r\nMea vidit epicuri intellegam an, elit molestie an pro. Vim aeterno indoctum ut, vel putent lucilius mandamus ei. Ex zril dolorum voluptatum eam. Lorem graece his te, ad diam congue eos. Primis vituperata necessitatibus vix an."
                        }
                    }
                    //,
                    //new Advert()
                    //{
                    //    TimeCreated = new(2023, 01, 02),
                    //    FirstName = "Josefin",
                    //    LastName = "Unefäldt",
                    //    Email = "jossebosse@gmail.com",
                    //    PhoneNumber = 123456789,
                    //    OfferingLooking = "Looking",
                    //    WorkspaceDescription = "Ceramics Studio",
                    //    City = "LONDON",
                    //    Area = "HACKNEY",
                    //    Amenities = new()
                    //    {
                    //        Parking = false,
                    //        AirCon = false,
                    //        Kitchen = false,
                    //        NaturalLight = false,
                    //        AcousticTreatment = true,
                    //        RunningWater = true,
                    //        Storage = true,
                    //        Other = "Oven"
                    //    },
                    //    Budgets = new()
                    //    {
                    //        MonthOrWeek = "Month",
                    //        Price = 100,
                    //    },
                    //    Measurements = new()
                    //    {
                    //        FeetOrMeters = "Square feet",
                    //        Number = 90,
                    //    },
                    //    DatesAndTimes = new()
                    //    {
                    //        StartDate = new(2023, 02, 01),
                    //        EndDate = new(2023, 06, 30),
                    //        OpeningTime = new(2023, 02, 14, 08, 00, 00),
                    //        ClosingTime = new(2024, 02, 14, 16, 30, 00),
                    //        Days = new()
                    //        {
                    //            Monday = true,
                    //            Tuesday = true,
                    //            Wednesday = true,
                    //            Thursday = false,
                    //            Friday = false,
                    //            Saturday = false,
                    //            Sunday = true
                    //        },
                    //    },
                    //    Artist = null,
                    //    SocialMedia = null,
                    //    Description = new()
                    //    {
                    //        ImgUrl = "seedImg/ceramicsLooking.jpg",
                    //        Desc = "Lorem ipsum dolor sit amet, volumus omittantur reformidans sit id, in homero ridens duo, verterem singulis pro no. Vim offendit tractatos eu. Ea magna audiam pro. Eu has alii adversarium. Ignota necessitatibus eu pri, vix id eius platonem.\r\n\r\nMea vidit epicuri intellegam an, elit molestie an pro. Vim aeterno indoctum ut, vel putent lucilius mandamus ei. Ex zril dolorum voluptatum eam. Lorem graece his te, ad diam congue eos. Primis vituperata necessitatibus vix an."
                    //    }
                    //}
                    //,
                    //new Advert()
                    //{
                    //    TimeCreated = new(2023, 01, 03),
                    //    FirstName = "Kalle",
                    //    LastName = "Josefsson",
                    //    Email = "test@gmail.com",
                    //    PhoneNumber = 123456789,
                    //    OfferingLooking = "Looking",
                    //    WorkspaceDescription = "Dance Rehersal Studio",
                    //    City = "GOTHENBURG",
                    //    Area = "MOLNDAL",
                    //    Amenities = new()
                    //    {
                    //        Parking = true,
                    //        AirCon = true,
                    //        Kitchen = true,
                    //        NaturalLight = false,
                    //        AcousticTreatment = false,
                    //        RunningWater = true,
                    //        Storage = true,
                    //        Other = "Lights"
                    //    },
                    //    Budgets = new()
                    //    {
                    //        MonthOrWeek = "Month",
                    //        Price = 150,
                    //    },
                    //    Measurements = new()
                    //    {
                    //        FeetOrMeters = "Square meters",
                    //        Number = 120,
                    //    },
                    //    DatesAndTimes = new()
                    //    {
                    //        StartDate = new(2023, 02, 01),
                    //        EndDate = new(2023, 06, 01),
                    //        OpeningTime = new(2023, 02, 14, 08, 00, 00),
                    //        ClosingTime = new(2024, 02, 14, 16, 30, 00),
                    //        Days = new()
                    //        {
                    //            Monday = true,
                    //            Tuesday = true,
                    //            Wednesday = true,
                    //            Thursday = true,
                    //            Friday = true,
                    //            Saturday = true,
                    //            Sunday = true
                    //        },
                    //    },
                    //    Artist = null,
                    //    SocialMedia = null,
                    //    Description = new()
                    //    {
                    //        ImgUrl = "seedImg/danceLooking.jpg",
                    //        Desc = "Lorem ipsum dolor sit amet, volumus omittantur reformidans sit id, in homero ridens duo, verterem singulis pro no. Vim offendit tractatos eu. Ea magna audiam pro. Eu has alii adversarium. Ignota necessitatibus eu pri, vix id eius platonem.\r\n\r\nMea vidit epicuri intellegam an, elit molestie an pro. Vim aeterno indoctum ut, vel putent lucilius mandamus ei. Ex zril dolorum voluptatum eam. Lorem graece his te, ad diam congue eos. Primis vituperata necessitatibus vix an."
                    //    }
                    //}
                    //,
                    //new Advert()
                    //{
                    //    TimeCreated = new(2023, 01, 04),
                    //    FirstName = "Sara",
                    //    LastName = "Andersson",
                    //    Email = "test@gmail.com",
                    //    PhoneNumber = 123456789,
                    //    OfferingLooking = "Looking",
                    //    WorkspaceDescription = "Music Studio",
                    //    City = "CARDIFF",
                    //    Area = "CENTER",
                    //    Amenities = new()
                    //    {
                    //        Parking = false,
                    //        AirCon = false,
                    //        Kitchen = false,
                    //        NaturalLight = false,
                    //        AcousticTreatment = true,
                    //        RunningWater = true,
                    //        Storage = true,
                    //        Other = "Drumset"
                    //    },
                    //    Budgets = new()
                    //    {
                    //        MonthOrWeek = "Month",
                    //        Price = 200,
                    //    },
                    //    Measurements = new()
                    //    {
                    //        FeetOrMeters = "Square meters",
                    //        Number = 80,
                    //    },
                    //    DatesAndTimes = new()
                    //    {
                    //        StartDate = new(2023, 05, 01),
                    //        EndDate = new(2024, 05, 01),
                    //        OpeningTime = new(2023, 05, 01, 08, 00, 00),
                    //        ClosingTime = new(2024, 05, 01, 22, 30, 00),
                    //        Days = new()
                    //        {
                    //            Monday = true,
                    //            Tuesday = true,
                    //            Wednesday = true,
                    //            Thursday = true,
                    //            Friday = true,
                    //            Saturday = true,
                    //            Sunday = true
                    //        },
                    //    },
                    //    Artist = "Madonna",
                    //    SocialMedia = null,
                    //    Description = new()
                    //    {
                    //        ImgUrl = "seedImg/musicLooking.jpg",
                    //        Desc = "Lorem ipsum dolor sit amet, volumus omittantur reformidans sit id, in homero ridens duo, verterem singulis pro no. Vim offendit tractatos eu. Ea magna audiam pro. Eu has alii adversarium. Ignota necessitatibus eu pri, vix id eius platonem.\r\n\r\nMea vidit epicuri intellegam an, elit molestie an pro. Vim aeterno indoctum ut, vel putent lucilius mandamus ei. Ex zril dolorum voluptatum eam. Lorem graece his te, ad diam congue eos. Primis vituperata necessitatibus vix an."
                    //    }
                    //}
                    //,
                    //new Advert()
                    //{
                    //    TimeCreated = new(2023, 01, 06),
                    //    FirstName = "Marie",
                    //    LastName = "Jansson",
                    //    Email = "test@gmail.com",
                    //    PhoneNumber = 123456789,
                    //    OfferingLooking = "Looking",
                    //    WorkspaceDescription = "Paint Studio",
                    //    City = "BRISTOL",
                    //    Area = "",
                    //    Amenities = new()
                    //    {
                    //        Parking = true,
                    //        AirCon = true,
                    //        Kitchen = true,
                    //        NaturalLight = true,
                    //        AcousticTreatment = false,
                    //        RunningWater = true,
                    //        Storage = true,
                    //        Other = ""
                    //    },
                    //    Budgets = new()
                    //    {
                    //        MonthOrWeek = "Month",
                    //        Price = 50,
                    //    },
                    //    Measurements = new()
                    //    {
                    //        FeetOrMeters = "Square feet",
                    //        Number = 30,
                    //    },
                    //    DatesAndTimes = new()
                    //    {
                    //        StartDate = new(2023, 02, 25),
                    //        EndDate = new(2023, 06, 01),
                    //        OpeningTime = new(2023, 02, 14, 08, 00, 00),
                    //        ClosingTime = new(2024, 02, 14, 16, 30, 00),
                    //        Days = new()
                    //        {
                    //            Monday = true,
                    //            Tuesday = true,
                    //            Wednesday = true,
                    //            Thursday = false,
                    //            Friday = true,
                    //            Saturday = true,
                    //            Sunday = true
                    //        },
                    //    },
                    //    Artist = null,
                    //    SocialMedia = null,
                    //    Description = new()
                    //    {
                    //        ImgUrl = "seedImg/paintLooking.jpg",
                    //        Desc = "Lorem ipsum dolor sit amet, volumus omittantur reformidans sit id, in homero ridens duo, verterem singulis pro no. Vim offendit tractatos eu. Ea magna audiam pro. Eu has alii adversarium. Ignota necessitatibus eu pri, vix id eius platonem.\r\n\r\nMea vidit epicuri intellegam an, elit molestie an pro. Vim aeterno indoctum ut, vel putent lucilius mandamus ei. Ex zril dolorum voluptatum eam. Lorem graece his te, ad diam congue eos. Primis vituperata necessitatibus vix an."
                    //    }
                    //}
                    //,
                    //// ALL OTHERS
                    //new Advert()
                    //{
                    //    TimeCreated = new(2023, 01, 04),
                    //    FirstName = "Sara",
                    //    LastName = "Andersson",
                    //    Email = "test@gmail.com",
                    //    PhoneNumber = 123456789,
                    //    OfferingLooking = "Offering",
                    //    WorkspaceDescription = "Yoga Studio",
                    //    City = "CARDIFF",
                    //    Area = "CENTER",
                    //    Amenities = new()
                    //    {
                    //        Parking = false,
                    //        AirCon = true,
                    //        Kitchen = false,
                    //        NaturalLight = false,
                    //        AcousticTreatment = false,
                    //        RunningWater = true,
                    //        Storage = true,
                    //        Other = "Yoga mats"
                    //    },
                    //    Budgets = new()
                    //    {
                    //        MonthOrWeek = "Month",
                    //        Price = 200,
                    //    },
                    //    Measurements = new()
                    //    {
                    //        FeetOrMeters = "Square meters",
                    //        Number = 80,
                    //    },
                    //    DatesAndTimes = new()
                    //    {
                    //        StartDate = new(2023, 05, 01),
                    //        EndDate = new(2024, 05, 01),
                    //        OpeningTime = new(2023, 05, 01, 08, 00, 00),
                    //        ClosingTime = new(2024, 05, 01, 22, 30, 00),
                    //        Days = new()
                    //        {
                    //            Monday = true,
                    //            Tuesday = true,
                    //            Wednesday = true,
                    //            Thursday = true,
                    //            Friday = true,
                    //            Saturday = true,
                    //            Sunday = true
                    //        },
                    //    },
                    //    Artist = null,
                    //    SocialMedia = null,
                    //    Description = new()
                    //    {
                    //        ImgUrl = "seedImg/yogaOffering.jpg",
                    //        Desc = "Lorem ipsum dolor sit amet, volumus omittantur reformidans sit id, in homero ridens duo, verterem singulis pro no. Vim offendit tractatos eu. Ea magna audiam pro. Eu has alii adversarium. Ignota necessitatibus eu pri, vix id eius platonem.\r\n\r\nMea vidit epicuri intellegam an, elit molestie an pro. Vim aeterno indoctum ut, vel putent lucilius mandamus ei. Ex zril dolorum voluptatum eam. Lorem graece his te, ad diam congue eos. Primis vituperata necessitatibus vix an."
                    //    }
                    //},
                    //new Advert()
                    //{
                    //    TimeCreated = new(2023, 01, 04),
                    //    FirstName = "Sara",
                    //    LastName = "Andersson",
                    //    Email = "test@gmail.com",
                    //    PhoneNumber = 123456789,
                    //    OfferingLooking = "Offering",
                    //    WorkspaceDescription = "Darkroom",
                    //    City = "LONDON",
                    //    Area = "CENTER",
                    //    Amenities = new()
                    //    {
                    //        Parking = false,
                    //        AirCon = false,
                    //        Kitchen = false,
                    //        NaturalLight = false,
                    //        AcousticTreatment = false,
                    //        RunningWater = true,
                    //        Storage = true,
                    //        Other = "Photo cutters"
                    //    },
                    //    Budgets = new()
                    //    {
                    //        MonthOrWeek = "Month",
                    //        Price = 200,
                    //    },
                    //    Measurements = new()
                    //    {
                    //        FeetOrMeters = "Square meters",
                    //        Number = 40,
                    //    },
                    //    DatesAndTimes = new()
                    //    {
                    //        StartDate = new(2023, 05, 01),
                    //        EndDate = new(2024, 05, 01),
                    //        OpeningTime = new(2023, 05, 01, 12, 00, 00),
                    //        ClosingTime = new(2024, 05, 01, 14, 30, 00),
                    //        Days = new()
                    //        {
                    //            Monday = true,
                    //            Tuesday = true,
                    //            Wednesday = false,
                    //            Thursday = false,
                    //            Friday = false,
                    //            Saturday = false,
                    //            Sunday = false
                    //        },
                    //    },
                    //    Artist = null,
                    //    SocialMedia = null,
                    //    Description = new()
                    //    {
                    //        ImgUrl = "seedImg/darkroom.jpg",
                    //        Desc = "Lorem ipsum dolor sit amet, volumus omittantur reformidans sit id, in homero ridens duo, verterem singulis pro no. Vim offendit tractatos eu. Ea magna audiam pro. Eu has alii adversarium. Ignota necessitatibus eu pri, vix id eius platonem.\r\n\r\nMea vidit epicuri intellegam an, elit molestie an pro. Vim aeterno indoctum ut, vel putent lucilius mandamus ei. Ex zril dolorum voluptatum eam. Lorem graece his te, ad diam congue eos. Primis vituperata necessitatibus vix an."
                    //    }
                    //},
                    //new Advert()
                    //{
                    //    TimeCreated = new(2023, 01, 04),
                    //    FirstName = "Sara",
                    //    LastName = "Andersson",
                    //    Email = "test@gmail.com",
                    //    PhoneNumber = 123456789,
                    //    OfferingLooking = "Looking",
                    //    WorkspaceDescription = "Film Studio",
                    //    City = "LONDON",
                    //    Area = "SOUTH",
                    //    Amenities = new()
                    //    {
                    //        Parking = false,
                    //        AirCon = false,
                    //        Kitchen = false,
                    //        NaturalLight = false,
                    //        AcousticTreatment = true,
                    //        RunningWater = true,
                    //        Storage = true,
                    //        Other = ""
                    //    },
                    //    Budgets = new()
                    //    {
                    //        MonthOrWeek = "Month",
                    //        Price = 200,
                    //    },
                    //    Measurements = new()
                    //    {
                    //        FeetOrMeters = "Square meters",
                    //        Number = 80,
                    //    },
                    //    DatesAndTimes = new()
                    //    {
                    //        StartDate = new(),
                    //        EndDate = new(),
                    //        OpeningTime = new(),
                    //        ClosingTime = new(),
                    //        Days = new()
                    //        {
                    //            Monday = false,
                    //            Tuesday = false,
                    //            Wednesday = false,
                    //            Thursday = false,
                    //            Friday = false,
                    //            Saturday = false,
                    //            Sunday = false
                    //        },
                    //    },
                    //    Artist = null,
                    //    SocialMedia = null,
                    //    Description = new()
                    //    {
                    //        ImgUrl = "seedImg/film.jpg",
                    //        Desc = "Lorem ipsum dolor sit amet, volumus omittantur reformidans sit id, in homero ridens duo, verterem singulis pro no. Vim offendit tractatos eu. Ea magna audiam pro. Eu has alii adversarium. Ignota necessitatibus eu pri, vix id eius platonem.\r\n\r\nMea vidit epicuri intellegam an, elit molestie an pro. Vim aeterno indoctum ut, vel putent lucilius mandamus ei. Ex zril dolorum voluptatum eam. Lorem graece his te, ad diam congue eos. Primis vituperata necessitatibus vix an."
                    //    }
                    //}
                    );

                if (context.Adverts.Any())
                {
                    return;   // DB has been seeded
                }


                context.SaveChanges();
            }
        }

    }
}


