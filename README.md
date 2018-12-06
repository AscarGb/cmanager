# cmanager
AspNetCore Identity simple console manager

Manage users, roles and claims

Compatible with <b>UserManager&lt;IdentityUser&gt;</b> and <b>RoleManager&lt;IdentityRole&gt;</b>

Supported databases: My SQl, Ms SQL

## Commands:

### add-user   
Add new user, roles, claims
```
  cmanager add-user Tom --claims Name:Tomas "City:Big City" --user-phone +79171234567 --password 123!@#qweQWE --role-names User
Admin NewRole
```
  -r, --role-names    - Required. Roles

  -p, --password      - Required. Password

  -m, --user-email    - Email

  -h, --user-phone    - Phone

  -c, --claims        - Claims

  value pos. 0        - Required. User name

 ### update-user   
 ```
cmanager update-user Tom --claims Name:Bobby "City:New York" --user-phone +7917999988 --new-name Bob --password
NewPassword!@#123 --role-names User Admin NewRole
```
  -r, --role-names    - New Roles

  -p, --password      - New Password

  -n, --new-name      - New user name

  -m, --user-email    - New Email

  -h, --user-phone    - New Phone

  -c, --claims        - New Claims

  value pos. 0        - Required. User name 

 ### find-user  
```
cmanager find-user [UserName]
```
  value pos. 0    - User name 

 ### delete-user  
 ```
 cmanager delete-user Tom 
```
  value pos. 0    - Required. User name 

 ### create-role 
 ```
 cmanager create-role NewRoleName
```
  value pos. 0    - Required. Role name 

 ### all-roles      
 Get all roles
  ```
 cmanager all-roles  
```

 ### add-role       
 Add role to user
 ```
 cmanager add-role Tom Role1 Role2
```
  value pos. 0    - Required. User name

  value pos. 1    - Required. Roles

 ### delete-role  
 ```
 cmanager delete-role Role1 Role2
```
  value pos. 0    - Required. Roles
 

 ### rename-role   
 ```
 cmanager rename-role RoleName NewRoleNAme
 ```
