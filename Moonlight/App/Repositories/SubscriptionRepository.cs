﻿using Microsoft.EntityFrameworkCore;
using FirePortal.App.Database;
using FirePortal.App.Database.Entities;

namespace FirePortal.App.Repositories;

public class SubscriptionRepository : IDisposable
{
    private readonly DataContext DataContext;

    public SubscriptionRepository(DataContext dataContext)
    {
        DataContext = dataContext;
    }

    public DbSet<Subscription> Get()
    {
        return DataContext.Subscriptions;
    }

    public Subscription Add(Subscription subscription)
    {
        var x = DataContext.Subscriptions.Add(subscription);
        DataContext.SaveChanges();
        return x.Entity;
    }

    public void Update(Subscription subscription)
    {
        DataContext.Subscriptions.Update(subscription);
        DataContext.SaveChanges();
    }
    
    public void Delete(Subscription subscription)
    {
        DataContext.Subscriptions.Remove(subscription);
        DataContext.SaveChanges();
    }

    public void Dispose()
    {
        DataContext.Dispose();
    }
}