using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using AutoReservation.Common.Interfaces;
using AutoReservation.Service.Wcf;

namespace AutoReservation.Ui.Factory
{
    public class RemoteDataAccessServiceFactory : IServiceFactory
    {
        public IAutoReservationService GetService()
        {
            //throw new NotImplementedException();
            return new ChannelFactory<IAutoReservationService>("AutoReservationService").CreateChannel();
        }
    }
}
