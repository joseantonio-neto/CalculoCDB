import { Component } from '@angular/core';
import { CalculateCdbService } from './services/calculate-cdb.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { GetCalculateResponse } from './services/models/getCalculateResponse';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  constructor(
    private readonly calculateCdbService: CalculateCdbService,
    private readonly toastr: ToastrService
  ) { }

  title = 'Cálculo de CDB';

  calculateForm = new FormGroup({
    initialValue: new FormControl('', [Validators.required, Validators.min(1)]),
    months: new FormControl('', [Validators.required, Validators.min(1)]),
  });

  calculateData = {} as GetCalculateResponse;

  currencyFormatter = Intl.NumberFormat('pt-BR', {
    currency: 'BRL',
    style: 'currency',
    minimumFractionDigits: 2,
    maximumFractionDigits: 2,
  });

  feeFormatter = Intl.NumberFormat('pt-BR', {
    style: 'percent',
    minimumFractionDigits: 2,
    maximumFractionDigits: 2,
  });

  fetchCalculateCdb(): void {
    const initialValue = Number(this.calculateForm.value.initialValue);
    const months = Number(this.calculateForm.value.months);

    if (!initialValue || initialValue <= 0 || !months || months <= 0) {
      this.toastr.warning(
        'O Valor Inicial e Número de Meses devem ser maior que zero.',
        'Atenção'
      );
      return;
    }

    this.calculateCdbService.getCalculate(initialValue, months).subscribe({
      next: (data: GetCalculateResponse) => {
        this.calculateData = data;
      },
      error: (error: Error) => {
        this.toastr.error(
          'Não foi possível acessar o servidor. Tente novamente mais tarde.',
          'Erro no sistema'
        );
        console.error('Error:', error);
      },
    });
  }
}
