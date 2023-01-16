﻿using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class OrderDetailService
    {
        private readonly ApplicationDbContext _context;
        private OrderDetailModel EntityToModel(OrderDetailsEntity entity)
        {
            OrderDetailModel result = new OrderDetailModel();
            result.Id = entity.Id;
            result.OrdersId= entity.OrdersId;
            result.ProductId= entity.ProductId;
            result.UnitPrice= entity.UnitPrice;
            result.Quantity= entity.Quantity;
            result.Discount= entity.Discount;

            return result;
        }

        private void ModelToEntity(OrderDetailModel model, OrderDetailsEntity entity)
        {
            entity.OrdersId= model.OrdersId;
            entity.ProductId= model.ProductId;
            entity.UnitPrice= model.UnitPrice;
            entity.Quantity= model.Quantity;
            entity.Discount= model.Discount;
        }

        public OrderDetailService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<OrderDetailsEntity> Get()
        {
            return _context.orderDetailsEntities.ToList();
        }

        public void Add(OrderDetailsEntity orderDetails)
        {
            _context.orderDetailsEntities.Add(orderDetails);
            _context.SaveChanges();
        }

        public OrderDetailModel View(int? id)
        {
            var orderDetail = _context.orderDetailsEntities.Find(id);
            return EntityToModel(orderDetail);
        }

        public void Update(OrderDetailModel orderDetails)
        {
            var entity = _context.orderDetailsEntities.Find(orderDetails.Id);
            ModelToEntity(orderDetails, entity);
            _context.orderDetailsEntities.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var entity = _context.orderDetailsEntities.Find(id);
            _context.orderDetailsEntities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
