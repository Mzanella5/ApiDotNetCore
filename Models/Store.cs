using System;
using System.Collections.Generic;

public class Store
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public int MaxNumberPeopleInStore { get; protected set; }
    public bool LimitedMaxNumberPeopleInStore { get; protected set; }
    public DateTime LastUpdate { get; private set; }
    public ICollection<Shift> Shifts { get; private set; }

    public Store(Guid Id, string Description, int MaxNumberPeopleInStore, bool LimitedMaxNumberPeopleInStore, DateTime LastUpdate)
    {
        this.Id = Id;
        this.Description = Description;
        this.MaxNumberPeopleInStore = MaxNumberPeopleInStore;
        this.LimitedMaxNumberPeopleInStore = LimitedMaxNumberPeopleInStore;
        this.LastUpdate = LastUpdate;
    }

}
