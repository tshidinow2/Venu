﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Serilog;
using Venu.Ticketing.Domain.Events;
using Venu.Ticketing.Domain.SeedWork;

namespace Venu.Ticketing.Domain.AggregatesModel.TicketAggregate
{
    [Table("Ticket")]
    public class Ticket : Entity, IAggregateRoot
    {
        [Key]
        [Column("TicketId")]
        public string Id { get; set; }
        public int SeatId { get; set; }
        public int CustomerId { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }
        
        public Ticket(int seatId, int customerId)
        {
            Id = Guid.NewGuid().ToString();
            SeatId = seatId;
            CustomerId = customerId;
            CreatedOn = DateTime.UtcNow;

            Log.Information($"Creating Ticket: {Id}, {SeatId}, {CustomerId}, {CreatedOn}");
            
            this.UpdateSeat(seatId);
        }

        private void UpdateSeat(int seatId)
        {
            var ticketCreatedDomainEvent = new TicketCreatedDomainEvent(seatId);
            AddDomainEvent(ticketCreatedDomainEvent);
        }
    }
}