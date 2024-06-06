const register = async () => {
    const newUser = {
        firstName: document.getElementById("firstName").value,
        lastName: document.getElementById("lastName").value,
        email: document.getElementById("email").value,
        password: document.getElementById("password").value
    };
    
    const response = await fetch('api/users', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newUser)
    });
    const register = await response.json();
    console.log('POST data: ', register);
    if (response.status == 400) {
        alert("סיסמה חלשה - פחות משתיים")
    }
    else {
        if (response.ok) {
            window.location.href = "Login.html"
        }
    }
    
}


const checkStrongPassword = async () => {
    const password = document.getElementById("password").value;
    const progress = document.getElementById("password-strength-progress");

    const response = await fetch('api/users/checkPassword', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(password)
    });

    const strong = await response.json();
    if (response.ok) {
        progress.value = strong; 
    }
}

const login = async () => {
    const loginUser = {
        email: document.getElementById("email").value,
        password: document.getElementById("password").value
    };
    const response = await fetch('api/users/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(loginUser)
    });
    const login = await response.json();
    if (response.ok) {
        sessionStorage.setItem("userId", JSON.stringify(login.userId))
        window.location.href = "Products.html"
    }
    else {
        alert("שם משתמש או הסיסמה אינם נכונים")
    }
}

const updateDetails = async () => {
    const updateUser = {
        firstName: document.getElementById("firstName").value,
        lastName: document.getElementById("lastName").value,
        email: document.getElementById("email").value,
        password: document.getElementById("password").value
    };
    const id = sessionStorage.getItem("userId");
    const response = await fetch(`api/users/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(updateUser)
    });
    if (response.status == 400) {
        alert("סיסמה חלשה - פחות משתיים")
    }
    else {
        if (response.ok) {
            alert("הפרטים עודכנו בהצלחה");
            window.location.href = "Products.html";
        }
    }
}