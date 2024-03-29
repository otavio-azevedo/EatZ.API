﻿using EatZ.Infra.CrossCutting.Enums;

namespace EatZ.API.Models.Orders.Reponses
{
    public record ListOrdersByCurrentUserResponse(long Id, string StoreName, EOrderStatus Status, DateTime CreationDate, DateTime? PickUpDate, decimal NetUnitPrice, int Quantity, decimal Total, short ReviewRate);
}