using CaseStudy_Quitq.Contexts;
using CaseStudy_Quitq.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaseStudy_Quitq.Repository
{
    public class SellerRepository : ISellerRepository
    {
        private readonly ApplicationDbContext _context;

        public SellerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Seller> GetAllSellers()
        {
            try
            {
                return _context.Sellers.Include(s => s.User).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving sellers: " + ex.Message);
            }
        }

        public Seller GetSellerById(int id)
        {
            try
            {
                return _context.Sellers.Include(s => s.User).FirstOrDefault(s => s.SellerId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving seller by ID: " + ex.Message);
            }
        }

        public List<Seller> GetSellersByName(string name)
        {
            try
            {
                return _context.Sellers
                    .Include(s => s.User)
                    .Where(s => !string.IsNullOrEmpty(s.SellerName) &&
                                s.SellerName.ToLower().Contains(name.ToLower()))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving sellers by name: " + ex.Message);
            }
        }

        public string AddSeller(Seller seller)
        {
            try
            {
                if (seller != null)
                {
                    _context.Sellers.Add(seller);
                    _context.SaveChanges();
                    return "Seller added successfully.";
                }
                return "Invalid seller data.";
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding seller: " + ex.Message);
            }
        }

        public string UpdateSeller(int id, Seller seller)
        {
            try
            {
                var existing = _context.Sellers.FirstOrDefault(s => s.SellerId == id);
                if (existing == null)
                    return $"Seller with ID {id} not found.";

                existing.SellerName = seller.SellerName;
                existing.CompanyName = seller.CompanyName;
                existing.Contact = seller.Contact;
                existing.SellerAddress = seller.SellerAddress;

                _context.SaveChanges();
                return $"Seller with ID {id} updated successfully.";
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating seller: " + ex.Message);
            }
        }

        public string DeleteSeller(int id)
        {
            try
            {
                var seller = _context.Sellers.FirstOrDefault(s => s.SellerId == id);
                if (seller == null)
                    return $"Seller with ID {id} not found.";

                _context.Sellers.Remove(seller);
                _context.SaveChanges();
                return $"Seller with ID {id} deleted successfully.";
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting seller: " + ex.Message);
            }
        }
    }
}
