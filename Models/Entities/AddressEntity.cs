﻿namespace Bmerketo.Models.Entities
{
    public class AddressEntity
    {
        public int Id { get; set; }

        public string StreetName { get; set; } = null!;

        public string? PostalCode { get; set; }

        public string? City { get; set; }

        public ICollection<UserAddressEntity> Users { get; set; } = new HashSet<UserAddressEntity>();

    }
}
