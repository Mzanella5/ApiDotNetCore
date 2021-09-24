using System;

public class Shift
{
	public Guid Id { get; private set; }
	public Guid StoreId { get; private set; }
	public Store Store { get; private set; }
	public TimeSpan StartAt { get; private set; }
	public TimeSpan EndAt { get; private set; }
	public DayOfWeek DayOfWeek { get; private set; }

	public Shift(Guid id, Guid storeId, TimeSpan startAt, TimeSpan endAt, DayOfWeek dayOfWeek){
		this.Id = id;
		this.StoreId = storeId;
		this.StartAt = startAt;
		this.EndAt = endAt;
		this.DayOfWeek = dayOfWeek;
	}

}