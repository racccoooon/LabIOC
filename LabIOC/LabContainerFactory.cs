﻿namespace LabIOC;

public class LabContainerFactory
{
    private readonly List<IocMapping> _registeredTypes = new ();

    private LabContainerFactory()
    {
    }

    public static LabContainerFactory Create()
    {
        return new LabContainerFactory();
    }

    public LabContainer Build()
    {
        return new LabContainer();
    }

    public LabContainerFactory Register(Type type)
    {
        return Register(type, type);
    }

    public LabContainerFactory Register(Type interfaceType, Type implementationType)
    {
        _registeredTypes.Add(new IocMapping(interfaceType, implementationType));
        return this;
    }

    public IEnumerable<IocMapping> GetMappings()
    {
        return _registeredTypes;
    }
}