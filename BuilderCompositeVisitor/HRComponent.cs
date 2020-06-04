using System;
using BuilderCompositeVisitor.Export;

namespace BuilderCompositeVisitor
{
    public abstract class HRComponent : IExport
    {
        public HRComponent() {}

        public virtual void Add(HRComponent component)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(HRComponent component)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsComposite()
        {
            return true;
        }

        public virtual void Export(IExportVisitor v)
        {
            throw new NotImplementedException();
        }

        public abstract decimal GetSalary();

        public abstract string GetInfo();
    }
}