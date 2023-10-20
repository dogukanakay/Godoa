﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGameDal : EfEntityRepositoryBase<Game, GodoaContext>, IGameDal
    {

        private IQueryable<GameDetailDto> GetGameDetailQuery(GodoaContext context)
        {
            return from g in context.Games
                   join c in context.Categories on g.CategoryId equals c.CategoryId
                   join p in context.Platforms on g.PlatformId equals p.PlatformId
                   join gt in context.GameTypes on g.TypeId equals gt.GameTypeId
                   select new GameDetailDto
                   {
                       GameId = g.GameId,
                       GameName = g.GameName,
                       CategoryName = c.CategoryName,
                       TypeName = gt.GameTypeName,
                       PlatformName = p.PlatformName,
                       Description = g.Description,
                       ImagePath = g.ImagePath

                   };
        }
        public List<GameDetailDto> GetGameDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetGameDetailQuery(context);
                return result.ToList();
            }
        }
    }
}
