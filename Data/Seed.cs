﻿using LingonberryStudio.Models;
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
                        Offering = true,
                        FirstName = "Karin",
                        LastName = "Eurenius",
                        Email = "kleurenius@gmail.com",
                        PhoneNumber = "0707310791",
                        Artist = "KarinSjunger",
                        SocialMedia = "@instagram KarinSjunger",
                        StudioType = "Art Studio",
                        WorkPlace = new()
                        {
                            City = "LONDON",
                            Area = "EAST",
                            ImgUrl = "seedImg/artOffering.jpg",
                            Description = "\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\"",
                            Period = "Month",
                            Currency = 100,
                            MeasurementType = "Meters",
                            MeasurementNumber = 50,
                            AmenityTypes = new()
                            {
                                Parking = true,
                                Shower = true,
                                AirCondition = true,
                                Kitchen = true,
                                NaturalLight = true,
                                AcousticTreatment = true,
                                RunningWater = true,
                                Storage = true,
                                Toilet = true,
                                CeramicOven = true,
                                Other = "Changing rooms"
                            },
                            TimeFrames = new()
                            {
                                OpeningTime = new(2023, 02, 14, 08, 30, 00),
                                ClosingTime = new(2024, 02, 14, 17, 30, 00),
                                StartDate = new(2023, 02, 14),
                                EndDate = new(2024, 02, 14),
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = false,
                                Sunday = false
                            },
                        },
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 01),
                        Offering = true,
                        FirstName = "Allan",
                        LastName = "Banan",
                        Email = "allan4twin@gmail.com",
                        PhoneNumber = "123456789",
                        Artist = null,
                        SocialMedia = null,
                        StudioType = "Photo Studio",
                        WorkPlace = new()
                        {
                            City = "STOCKHOLM",
                            Area = "SOLNA",
                            ImgUrl = "seedImg/photoOffering.jpg",
                            Description = "\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\"",
                            Period = "Month",
                            Currency = 135,
                            MeasurementType = "Feet",
                            MeasurementNumber = 90,
                            AmenityTypes = new()
                            {
                                Parking = false,
                                Shower = true,
                                AirCondition = false,
                                Kitchen = false,
                                NaturalLight = true,
                                AcousticTreatment = false,
                                RunningWater = true,
                                Storage = true,
                                Toilet = true,
                                CeramicOven = false,
                                Other = "Tripod"
                            },
                            TimeFrames = new()
                            {
                                OpeningTime = new(2023, 02, 14, 12, 30, 00),
                                ClosingTime = new(2024, 02, 14, 21, 30, 00),
                                StartDate = new(2023, 02, 01),
                                EndDate = new(2023, 03, 14),
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = true,
                                Sunday = true
                            },
                        },
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 02),
                        Offering = true,
                        FirstName = "Josefin",
                        LastName = "Unefäldt",
                        Email = "jossebosse@gmail.com",
                        PhoneNumber = "123456789",
                        Artist = null,
                        SocialMedia = null,
                        StudioType = "Ceramics Studio",
                        WorkPlace = new()
                        {
                            City = "LONDON",
                            Area = "HACKNEY",
                            ImgUrl = "seedImg/ceramicsOffering.jpg",
                            Description = "\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\"",
                            Period = "Month",
                            Currency = 115,
                            MeasurementType = "Feet",
                            MeasurementNumber = 110,
                            AmenityTypes = new()
                            {
                                Parking = false,
                                Shower = false,
                                AirCondition = false,
                                Kitchen = false,
                                NaturalLight = true,
                                AcousticTreatment = false,
                                RunningWater = true,
                                Storage = true,
                                Toilet = true,
                                CeramicOven = true,
                                Other = "Oven"
                            },
                            TimeFrames = new()
                            {
                                OpeningTime = new(2023, 02, 14, 08, 00, 00),
                                ClosingTime = new(2024, 02, 14, 16, 30, 00),
                                StartDate = new(2023, 02, 01),
                                EndDate = new(2023, 06, 30),
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = false,
                                Friday = false,
                                Saturday = false,
                                Sunday = true
                            },
                        },
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 03),
                        Offering = true,
                        FirstName = "Kalle",
                        LastName = "Josefsson",
                        Email = "test@gmail.com",
                        PhoneNumber = "123456789",
                        Artist = null,
                        SocialMedia = null,
                        StudioType = "DanceRehersal Studio",
                        WorkPlace = new()
                        {
                            City = "GOTHENBURG",
                            Area = "MOLNDAL",
                            ImgUrl = "seedImg/danceOffering.jpg",
                            Description = "\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\"",
                            Period = "Month",
                            Currency = 115,
                            MeasurementType = "Feet",
                            MeasurementNumber = 110,
                            AmenityTypes = new()
                            {
                                Parking = false,
                                Shower = true,
                                AirCondition = true,
                                Kitchen = false,
                                NaturalLight = true,
                                AcousticTreatment = false,
                                RunningWater = true,
                                Storage = true,
                                Toilet = true,
                                CeramicOven = false,
                                Other = "Lights"
                            },
                            TimeFrames = new()
                            {
                                OpeningTime = new(2023, 02, 14, 08, 00, 00),
                                ClosingTime = new(2024, 02, 14, 16, 30, 00),
                                StartDate = new(2023, 02, 01),
                                EndDate = new(2023, 06, 01),
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = true,
                                Sunday = true
                            },
                        },
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 04),
                        Offering = true,
                        FirstName = "Sara",
                        LastName = "Andersson",
                        Email = "test@gmail.com",
                        PhoneNumber = "123456789",
                        Artist = "Madonna",
                        SocialMedia = null,
                        StudioType = "Music Studio",
                        WorkPlace = new()
                        {
                            City = "CARDIFF",
                            Area = "CENTER",
                            ImgUrl = "seedImg/musicOffering.jpg",
                            Description = "\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\"",
                            Period = "Week",
                            Currency = 70,
                            MeasurementType = "Meters",
                            MeasurementNumber = 43,
                            AmenityTypes = new()
                            {
                                Parking = false,
                                Shower = true,
                                AirCondition = true,
                                Kitchen = false,
                                NaturalLight = true,
                                AcousticTreatment = true,
                                RunningWater = true,
                                Storage = true,
                                Toilet = true,
                                CeramicOven = false,
                                Other = "Drumset"
                            },
                            TimeFrames = new()
                            {
                                OpeningTime = new(2023, 05, 01, 08, 00, 00),
                                ClosingTime = new(2024, 05, 01, 22, 30, 00),
                                StartDate = new(2023, 05, 01),
                                EndDate = new(2024, 05, 01),
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = true,
                                Sunday = true
                            },
                        },
                    },
                    // ALL Looking
                    new Advert()
                    {
                        TimeCreated = DateTime.Today,
                        Offering = false,
                        FirstName = "Karin",
                        LastName = "Eurenius",
                        Email = "kleurenius@gmail.com",
                        PhoneNumber = "123456789",
                        Artist = "KarinSjunger",
                        SocialMedia = "@instagram KarinSjunger",
                        StudioType = "Art Studio",
                        WorkPlace = new()
                        {
                            City = "LONDON",
                            Area = "EAST",
                            ImgUrl = "seedImg/artLooking.jpg",
                            Description = "\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\"",
                            Period = "Month",
                            Currency = 100,
                            MeasurementType = "Meters",
                            MeasurementNumber = 50,
                            AmenityTypes = new()
                            {
                                Parking = true,
                                Shower = true,
                                AirCondition = true,
                                Kitchen = true,
                                NaturalLight = true,
                                AcousticTreatment = true,
                                RunningWater = true,
                                Storage = true,
                                Toilet = true,
                                CeramicOven = true,
                                Other = "Changing rooms"
                            },
                            TimeFrames = new()
                            {
                                OpeningTime = new(2023, 02, 14, 08, 30, 00),
                                ClosingTime = new(2024, 02, 14, 17, 30, 00),
                                StartDate = new(2023, 02, 14),
                                EndDate = new(2024, 02, 14),
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = false,
                                Sunday = false
                            },
                        },
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 01),
                        Offering = false,
                        FirstName = "Allan",
                        LastName = "Banan",
                        Email = "allan4twin@gmail.com",
                        PhoneNumber = "123456789",
                        Artist = null,
                        SocialMedia = null,
                        StudioType = "Photo Studio",
                        WorkPlace = new()
                        {
                            City = "STOCKHOLM",
                            Area = "SOLNA",
                            ImgUrl = "seedImg/photoLooking.jpg",
                            Description = "\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\"",
                            Period = "Month",
                            Currency = 135,
                            MeasurementType = "Feet",
                            MeasurementNumber = 90,
                            AmenityTypes = new()
                            {
                                Parking = false,
                                Shower = true,
                                AirCondition = false,
                                Kitchen = false,
                                NaturalLight = true,
                                AcousticTreatment = false,
                                RunningWater = true,
                                Storage = true,
                                Toilet = true,
                                CeramicOven = false,
                                Other = "Tripod"
                            },
                            TimeFrames = new()
                            {
                                OpeningTime = new(2023, 02, 14, 12, 30, 00),
                                ClosingTime = new(2024, 02, 14, 21, 30, 00),
                                StartDate = new(2023, 02, 01),
                                EndDate = new(2023, 03, 14),
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = true,
                                Sunday = true
                            },
                        },
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 02),
                        Offering = false,
                        FirstName = "Josefin",
                        LastName = "Unefäldt",
                        Email = "jossebosse@gmail.com",
                        PhoneNumber = "123456789",
                        Artist = null,
                        SocialMedia = null,
                        StudioType = "Ceramics Studio",
                        WorkPlace = new()
                        {
                            City = "LONDON",
                            Area = "HACKNEY",
                            ImgUrl = "seedImg/ceramicsLooking.jpg",
                            Description = "\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\"",
                            Period = "Month",
                            Currency = 115,
                            MeasurementType = "Feet",
                            MeasurementNumber = 110,
                            AmenityTypes = new()
                            {
                                Parking = false,
                                Shower = false,
                                AirCondition = false,
                                Kitchen = false,
                                NaturalLight = true,
                                AcousticTreatment = false,
                                RunningWater = true,
                                Storage = true,
                                Toilet = true,
                                CeramicOven = true,
                                Other = "Oven"
                            },
                            TimeFrames = new()
                            {
                                OpeningTime = new(2023, 02, 14, 08, 00, 00),
                                ClosingTime = new(2024, 02, 14, 16, 30, 00),
                                StartDate = new(2023, 02, 01),
                                EndDate = new(2023, 06, 30),
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = false,
                                Friday = false,
                                Saturday = false,
                                Sunday = true
                            },
                        },
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 03),
                        Offering = false,
                        FirstName = "Kalle",
                        LastName = "Josefsson",
                        Email = "test@gmail.com",
                        PhoneNumber = "123456789",
                        Artist = null,
                        SocialMedia = null,
                        StudioType = "DanceRehersal Studio",
                        WorkPlace = new()
                        {
                            City = "GOTHENBURG",
                            Area = "MOLNDAL",
                            ImgUrl = "seedImg/danceLooking.jpg",
                            Description = "\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\"",
                            Period = "Month",
                            Currency = 115,
                            MeasurementType = "Feet",
                            MeasurementNumber = 110,
                            AmenityTypes = new()
                            {
                                Parking = false,
                                Shower = true,
                                AirCondition = true,
                                Kitchen = false,
                                NaturalLight = true,
                                AcousticTreatment = false,
                                RunningWater = true,
                                Storage = true,
                                Toilet = true,
                                CeramicOven = false,
                                Other = "Lights"
                            },
                            TimeFrames = new()
                            {
                                OpeningTime = new(2023, 02, 14, 08, 00, 00),
                                ClosingTime = new(2024, 02, 14, 16, 30, 00),
                                StartDate = new(2023, 02, 01),
                                EndDate = new(2023, 06, 01),
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = true,
                                Sunday = true
                            },
                        },
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 04),
                        Offering = false,
                        FirstName = "Sara",
                        LastName = "Andersson",
                        Email = "test@gmail.com",
                        PhoneNumber = "123456789",
                        Artist = "Madonna",
                        SocialMedia = null,
                        StudioType = "Music Studio",
                        WorkPlace = new()
                        {
                            City = "CARDIFF",
                            Area = "CENTER",
                            ImgUrl = "seedImg/musicLooking.jpg",
                            Description = "\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\"",
                            Period = "Month",
                            Currency = 200,
                            MeasurementType = "Meters",
                            MeasurementNumber = 43,
                            AmenityTypes = new()
                            {
                                Parking = false,
                                Shower = true,
                                AirCondition = true,
                                Kitchen = false,
                                NaturalLight = true,
                                AcousticTreatment = true,
                                RunningWater = true,
                                Storage = true,
                                Toilet = true,
                                CeramicOven = false,
                                Other = "Drumset"
                            },
                            TimeFrames = new()
                            {
                                OpeningTime = new(2023, 05, 01, 08, 00, 00),
                                ClosingTime = new(2024, 05, 01, 22, 30, 00),
                                StartDate = new(2023, 05, 01),
                                EndDate = new(2024, 05, 01),
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = true,
                                Sunday = true
                            },
                        },
                    },
                    // ALL OTHERS
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 04),
                        Offering = true,
                        FirstName = "Sara",
                        LastName = "Andersson",
                        Email = "test@gmail.com",
                        PhoneNumber = "123456789",
                        Artist = "Madonna",
                        SocialMedia = null,
                        StudioType = "Yoga Studio",
                        WorkPlace = new()
                        {
                            City = "CARDIFF",
                            Area = "CENTER",
                            ImgUrl = "seedImg/yogaOffering.jpg",
                            Description = "\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\"",
                            Period = "Month",
                            Currency = 255,
                            MeasurementType = "Meters",
                            MeasurementNumber = 43,
                            AmenityTypes = new()
                            {
                                Parking = false,
                                Shower = true,
                                AirCondition = true,
                                Kitchen = false,
                                NaturalLight = true,
                                AcousticTreatment = true,
                                RunningWater = true,
                                Storage = true,
                                Toilet = true,
                                CeramicOven = false,
                                Other = "Yoga mats"
                            },
                            TimeFrames = new()
                            {
                                OpeningTime = new(2023, 05, 01, 08, 00, 00),
                                ClosingTime = new(2024, 05, 01, 22, 30, 00),
                                StartDate = new(2023, 05, 01),
                                EndDate = new(2024, 05, 01),
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = true,
                                Sunday = true
                            },
                        },
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 04),
                        Offering = true,
                        FirstName = "Sara",
                        LastName = "Andersson",
                        Email = "test@gmail.com",
                        PhoneNumber = "123456789",
                        Artist = "Madonna",
                        SocialMedia = null,
                        StudioType = "Darkroom",
                        WorkPlace = new()
                        {
                            City = "CARDIFF",
                            Area = "CENTER",
                            ImgUrl = "seedImg/darkroom.jpg",
                            Description = "\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\"",
                            Period = "Week",
                            Currency = 45,
                            MeasurementType = "Meters",
                            MeasurementNumber = 43,
                            AmenityTypes = new()
                            {
                                Parking = false,
                                Shower = true,
                                AirCondition = true,
                                Kitchen = false,
                                NaturalLight = true,
                                AcousticTreatment = true,
                                RunningWater = true,
                                Storage = true,
                                Toilet = true,
                                CeramicOven = false,
                                Other = "Chemicals"
                            },
                            TimeFrames = new()
                            {
                                OpeningTime = new(2023, 05, 01, 08, 00, 00),
                                ClosingTime = new(2024, 05, 01, 22, 30, 00),
                                StartDate = new(2023, 05, 01),
                                EndDate = new(2024, 05, 01),
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = true,
                                Sunday = true
                            },
                        },
                    },
                    new Advert()
                    {
                        TimeCreated = new(2023, 01, 04),
                        Offering = false,
                        FirstName = "Sara",
                        LastName = "Andersson",
                        Email = "test@gmail.com",
                        PhoneNumber = "123456789",
                        Artist = "Madonna",
                        SocialMedia = null,
                        StudioType = "Film Studio",
                        WorkPlace = new()
                        {
                            City = "CARDIFF",
                            Area = "CENTER",
                            ImgUrl = "seedImg/film.jpg",
                            Description = "\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\"",
                            Period = "Week",
                            Currency = 75,
                            MeasurementType = "Meters",
                            MeasurementNumber = 43,
                            AmenityTypes = new()
                            {
                                Parking = false,
                                Shower = true,
                                AirCondition = true,
                                Kitchen = false,
                                NaturalLight = true,
                                AcousticTreatment = true,
                                RunningWater = true,
                                Storage = true,
                                Toilet = true,
                                CeramicOven = false,
                                Other = null
                            },
                            TimeFrames = new()
                            {
                                OpeningTime = new(2023, 05, 01, 08, 00, 00),
                                ClosingTime = new(2024, 05, 01, 22, 30, 00),
                                StartDate = new(2023, 05, 01),
                                EndDate = new(2024, 05, 01),
                                Monday = true,
                                Tuesday = true,
                                Wednesday = true,
                                Thursday = true,
                                Friday = true,
                                Saturday = true,
                                Sunday = true
                            },
                        },
                    }
                    );
                context.SaveChanges();
            }
        }

    }
}


