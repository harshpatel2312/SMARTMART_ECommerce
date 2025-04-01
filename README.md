# SMARTMART_ECOMMERCE: A Secure Online Shopping Platform

## Overview
**SMARTMART_ECOMMERCE** is a **feature-rich eCommerce web application** developed using **ASP.NET** that enables users to browse, purchase, and manage orders seamlessly, similar to platforms like Amazon. The project emphasizes **secure session management** and **enhanced user authentication**, ensuring a safe and efficient shopping experience.

## Key Features
- **User Authentication & Authorization**: Secure login and registration using **BCrypt hashing** for password protection.
- **Session Management**: Maintains user sessions securely, preventing unauthorized access and session hijacking.
- **Product Browsing & Shopping Cart**: Users can browse products, add them to the cart, and proceed to checkout.
- **Order Management**: Tracks user orders, order history, and payment details.
- **Admin Dashboard**: Allows product and user management with role-based access control.
- **Security Enhancements**: Protection against **SQL injection, CSRF attacks, and session fixation vulnerabilities**.

## Technologies Used
- **Backend**: ASP.NET Core
- **Frontend**: Razor Pages, HTML, CSS, JavaScript
- **Database**: SQLite
- **Security Measures**: BCrypt for password hashing, secure session tokens, role-based authentication
- **Tools & Frameworks**: Entity Framework Core, Identity Framework

## My Contributions
As a **key contributor** to the project, I was responsible for **session management and security enhancements**, ensuring a robust and secure user experience. My work included:

### **Implementing Secure Session Management**  
- Designed and implemented **secure session handling mechanisms** to prevent session hijacking.  
- Enforced **automatic session expiration** and token-based validation for user activity tracking.  

### **Enhancing Authentication & Security**  
- Integrated **BCrypt hashing** to securely store user credentials.  
- Secured API endpoints against **common security threats** such as CSRF, SQL injection, and XSS.  

## Installation & Setup
1. **Clone the Repository**
   ```bash
   git clone https://github.com/harshpatel2312/SMARTMART_ECOMMERCE.git
   cd SMARTMART_ECOMMERCE
   
2. **Configure the Database**
  - Update the `appsettings.json` file with your SQLite connection string.
  - Run migrations using Entity Framework:

    ```bash
    dotnet ef database update

3. **Run the application**
   ```bash
   dotnet run

## Future Enhancements
- **Implement OAuth-based authentication** (Google/Facebook login)  
- **Integrate payment gateway support** (Stripe/PayPal)  
- **Improve UI/UX with modern design frameworks**  

## Conclusion
**SMARTMART_ECOMMERCE** is designed to provide a **secure, scalable, and user-friendly online shopping experience**. With advanced **session management and security features**, it ensures a safe and seamless interaction for users. Contributions and feedback are welcome—feel free to explore, fork, and contribute!
