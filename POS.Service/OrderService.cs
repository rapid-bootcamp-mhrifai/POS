using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;
        private OrderModel EntityToModel(OrdersEntity entity)
        {
            OrderModel result = new OrderModel();
            result.Id = entity.Id;
            result.CustomersId = entity.CustomersId;
            result.EmployeesId = entity.EmployeesId;
            result.OrderDate = entity.OrderDate;
            result.RequiredDate= entity.RequiredDate;
            result.ShippedDate = entity.ShippedDate;
            result.ShipperId = entity.ShipperId;
            result.ShipVia = entity.ShipVia;
            result.Freight = entity.Freight;
            result.ShipName = entity.ShipName;
            result.ShipAddress = entity.ShipAddress;
            result.ShipCity = entity.ShipCity;
            result.ShipRegion = entity.ShipRegion;
            result.ShipPostalCode = entity.ShipPostalCode;
            result.ShipCountry = entity.ShipCountry;
            result.OrderDetailModels = new List<OrderDetailModel>();
            foreach (var item in entity.orderDetailsEntities)
            {
                result.OrderDetailModels.Add(EntityToModelOrdDet(item));
            }

            return result;
        }

        private OrderDetailModel EntityToModelOrdDet(OrderDetailsEntity entity)
        {
            OrderDetailModel model = new OrderDetailModel();
            model.Id = entity.Id;
            model.ProductId = entity.ProductId;
            model.UnitPrice = entity.UnitPrice;
            model.Quantity = entity.Quantity;
            model.Discount = entity.Discount;

            return model;
        }


        private OrdersEntity ModelToEntity(OrderModel model)
        {
            OrdersEntity entity = new OrdersEntity();
            entity.CustomersId = model.CustomersId;
            entity.EmployeesId = model.EmployeesId;
            entity.OrderDate = model.OrderDate;
            entity.RequiredDate = model.RequiredDate;
            entity.ShippedDate = model.ShippedDate;
            entity.ShipperId = model.ShipperId;
            entity.ShipVia = model.ShipVia;
            entity.Freight = model.Freight;
            entity.ShipName = model.ShipName;
            entity.ShipAddress = model.ShipAddress;
            entity.ShipCity = model.ShipCity;
            entity.ShipRegion = model.ShipRegion;
            entity.ShipPostalCode = model.ShipPostalCode;
            entity.ShipCountry = model.ShipCountry;
            entity.orderDetailsEntities = new List<OrderDetailsEntity>();
            foreach (var item in model.OrderDetailModels)
            {
                entity.orderDetailsEntities.Add(ModelToEntityOrdDet(item));
            }

            return entity;
        }

        private OrderDetailsEntity ModelToEntityOrdDet(OrderDetailModel model)
        {
            OrderDetailsEntity entity = new OrderDetailsEntity();
            entity.OrdersId = model.OrdersId;
            entity.ProductId = model.ProductId;
            entity.UnitPrice = model.UnitPrice;
            entity.Quantity = model.Quantity;
            entity.Discount = model.Discount;

            return entity;
        }


        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<OrdersEntity> Get()
        {
            return _context.ordersEntities.ToList();
        }

        /*public void Add(OrdersEntity orders)
        {
            _context.ordersEntities.Add(orders);
            _context.SaveChanges();
        }*/

        public void Add(OrderModel newOrder)
        {
            var newData = ModelToEntity(newOrder);
            _context.ordersEntities.Add(newData);
            foreach (var item in newData.orderDetailsEntities)
            {
                item.OrdersId = newOrder.Id;
                _context.orderDetailsEntities.Add(item);
            }
            _context.SaveChanges();
        }


        public OrderModel View(int? id)
        {
            var order = _context.ordersEntities.Find(id);
            return EntityToModel(order);
        }

        public void Update(OrderModel orders)
        {
            /*var entity = _context.ordersEntities.Find(orders.Id);
            ModelToEntity(orders, entity);
            _context.ordersEntities.Update(entity);
            _context.SaveChanges();*/

            var entityOrder = _context.ordersEntities.Find(orders.Id);
            var orderDetailList = _context.orderDetailsEntities.Where(x => x.OrdersId == orders.Id).ToList();

            // convert model with updated data into entity
            var updatedEntity = ModelToEntity(orders);

            // copy all property
            entityOrder.CustomersId = updatedEntity.CustomersId;
            entityOrder.EmployeesId = updatedEntity.EmployeesId;
            entityOrder.OrderDate = updatedEntity.OrderDate;
            entityOrder.RequiredDate = updatedEntity.RequiredDate;
            entityOrder.ShippedDate = updatedEntity.ShippedDate;
            entityOrder.ShipperId = updatedEntity.ShipperId;
            entityOrder.Freight = updatedEntity.Freight;
            entityOrder.ShipName = updatedEntity.ShipName;
            entityOrder.ShipAddress = updatedEntity.ShipAddress;
            entityOrder.ShipCity = updatedEntity.ShipCity;
            entityOrder.ShipRegion = updatedEntity.ShipRegion;
            entityOrder.ShipPostalCode = updatedEntity.ShipPostalCode;
            entityOrder.ShipCountry = updatedEntity.ShipCountry;
            entityOrder.orderDetailsEntities = updatedEntity.orderDetailsEntities;

            // update order entity
            _context.ordersEntities.Update(entityOrder);

            foreach (var newItem in entityOrder.orderDetailsEntities)
            {
                newItem.OrdersId = orders.Id;
                foreach (var item in orderDetailList)
                {
                    if (newItem.ProductId == item.ProductId)
                    {
                        item.ProductId = newItem.ProductId;
                        item.UnitPrice = newItem.UnitPrice;
                        item.Quantity = newItem.Quantity;
                        item.Discount = newItem.Discount;

                        // update order detail entity
                        _context.orderDetailsEntities.Update(item);
                    }
                }

            }
            // save updated order & order entity
            _context.SaveChanges();

        }

        public void Delete(int? id)
        {
            var entity = _context.ordersEntities.Find(id);
            _context.ordersEntities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
