using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LingonberryStudio.Data.Entities;
using LingonberryStudio.Models;
using LingonberryStudio.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LingonberryStudio.Data.Repositories
{
    public class AdvertRepository
    {
        private readonly LingonberryDbContext db;
        public AdvertRepository(LingonberryDbContext dbContext)
        {
            db = dbContext;
        }

        public List<PreviewAdvert> GetAllPreviewAdsInDB(string queryString)
        {
            List<PreviewAdvert> allPreviewAds = db.Adverts
               .FromSqlRaw(queryString) // Use the provided query string
               .OrderBy(p => p.TimeCreated)
               .Reverse()
               .AsNoTracking()
               .Select(p => new PreviewAdvert
               {
                   ID = p.ID,
                   TimeCreated = p.TimeCreated,
                   Offering = p.Offering,
                   StudioType = p.StudioType,
                   Pounds = p.Pounds,
                   ImgUrl = p.ImgUrl,
                   City = p.City,
                   Period = p.Period
               })
               .ToList();

            return allPreviewAds;
        }

        public List<PreviewAdvert> GetAllPreviewAdsInDB()
        {
            List<PreviewAdvert> allPreviewAds = db.Adverts
               .OrderBy(p => p.TimeCreated)
               .Reverse()
               .AsNoTracking()
               .Select(p => new PreviewAdvert
               {
                   ID = p.ID,
                   TimeCreated = p.TimeCreated,
                   Offering = p.Offering,
                   StudioType = p.StudioType,
                   Pounds = p.Pounds,
                   ImgUrl = p.ImgUrl,
                   City = p.City,
                   Period = p.Period
               })
               .ToList();

            return allPreviewAds;
        }
    }
}
