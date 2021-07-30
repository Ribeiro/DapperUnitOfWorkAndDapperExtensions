using System;


namespace DapperUnitOfWorkAndDapperExtensionsExample.Models
{
    public abstract class BasePoco
    {
        public Guid Id { get; set; }

        public virtual void SetDbId(object id)
        {
            //Each POCO should override this method for specific implementation.
            throw new NotImplementedException("This method is not implemented by Poco.");
        }

        public override string ToString()
        {
            return Id + Environment.NewLine + base.ToString();
        }
    }
}
