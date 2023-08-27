import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from './Model/product';
import { Pagination } from './Model/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Skinet';
  products: Product[] = [];

  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    this.http.get<Pagination<Product[]>>('https://localhost:5001/api/products?pagesize=50').subscribe({
      next: response => this.products = response.data,
      error: error => console.error(error),
      complete: () => {
        console.log('Request completed');
        console.log('Extra statment');
      }
    })
  }
}
