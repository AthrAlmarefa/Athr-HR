export * from './category.service';
import { CategoryService } from './category.service';
export * from './users.service';
import { UsersService } from './users.service';
export const APIS = [CategoryService, UsersService];
