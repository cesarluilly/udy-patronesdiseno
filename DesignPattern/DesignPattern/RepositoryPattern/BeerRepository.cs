﻿using DesignPattern.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.RepositoryPattern
{
    public class BeerRepository : IBeerRepository
    {
        private DesignPatternContext _context;

        public BeerRepository(DesignPatternContext context)
        {
            this._context = context;
        }

        public void Add(Beer data) => _context.Beers.Add(data);

        public void Delete(int intId)
        {
            var beer = _context.Beers.Find(intId);
            _context.Beers.Remove(beer);
        }
        public IEnumerable<Beer> Get() => _context.Beers.ToList();

        public Beer Get(int id) => _context.Beers.Find(id);

        public void Update(Beer data) => 
            _context.Entry(data).State = EntityState.Modified;

        public void Save() => _context.SaveChanges();

        
    }
}
