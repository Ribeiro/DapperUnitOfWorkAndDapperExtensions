using System;


namespace DapperUnitOfWorkAndDapperExtensionsExample.Models
{
    public class Notifications : BasePoco
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }

        public override void SetDbId(object id)
        {
            base.SetDbId(id);
        }

    }

}