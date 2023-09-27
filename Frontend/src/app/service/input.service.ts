import { DatePipe } from '@angular/common';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class InputService {

  constructor(private datePipe: DatePipe) { }

  formatNumber(number: any) {
    return number.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".");
  }

  formatDate(date :any)
  {
      const formattedDate = this.datePipe.transform(date, 'yyyy-MM-dd');
      return formattedDate;
  }
}
