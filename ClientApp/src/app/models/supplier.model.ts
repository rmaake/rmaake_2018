import { SupplierAccount } from "./supplierAccount.model";

export class Supplier {
  supplierId: number;
  name: string;
  address: string;
  tell: string;
  email: string;
  supplierAccounts: SupplierAccount[];
}
