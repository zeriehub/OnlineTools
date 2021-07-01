using Microsoft.AspNetCore.Components.Server.Circuits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using WellMadeApp.ViewModels;
using WellMadeApp.Pages.DataAccessPages;
using Microsoft.JSInterop;
using Blazored.LocalStorage.StorageOptions;
using Microsoft.Extensions.Options;
using WellMadeApp.Models;

namespace WellMadeApp
{
    public class Tracker:CircuitHandler
    {

        private DashboardViewModel DVM;
        
        private HashSet<Circuit> circuits = new HashSet<Circuit>();
     
        public event EventHandler CircuitsChanged;

        protected virtual void OnCircuitsChanged() => CircuitsChanged?.Invoke(this, EventArgs.Empty);

        public override async Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            
            circuits.Add(circuit);
            OnCircuitsChanged();
            await base.OnCircuitClosedAsync(circuit, cancellationToken);
        }

       
        public override async Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            circuits.Remove(circuit);
            OnCircuitsChanged();
            await base.OnCircuitClosedAsync(circuit, cancellationToken);
        }
    }
}
//GVM.filteredSelectBoxes.Last().Value.Count > 0