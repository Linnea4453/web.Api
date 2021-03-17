let regbutton = document.getElementById('register')
let loginbutton = document.getElementById('login')
let getbutton = document.getElementById('get')
let logoutbutton = document.getElementById('logout')

let registerobj = {
    firstName: "Jonas",
    lastName: "Nilsson",
    email: "Jonas@Nilsson.se",
    password: "BytMig123!"
}



let loginobj = {
    email: registerobj.email,
    password: registerobj.password
}

let token


regbutton.addEventListener("click", (e)=> {
    let json = JSON.stringify(registerobj)

    fetch("https://localhost:44336/api/Serviceworkers/register",{
        method: 'POST',
        headers: {
            'Accept': 'application/json, text/plain',
            'Content-Type': 'application/json;charset=UTF-8'
        },
        body: json
    })
})

loginbutton.addEventListener("click", (e)=> {
    let json = JSON.stringify(loginobj)

    fetch("https://localhost:44336/api/Serviceworkers/login",{
        method: 'POST',
        headers: {
            'Accept': 'application/json, text/plain',
            'Content-Type': 'application/json;charset=UTF-8'
        },
        body: json
    })
    .then(res => res.json())
    .then(data => {
        token = data.token

        localStorage.setItem("token", token)
        sessionStorage.setItem("token", token)

        console.log(token)
    })
    .catch(error => console.log(error))
})

getbutton.addEventListener("click", (e)=> {
    token = sessionStorage.getItem("token")

    fetch("https://localhost:44336/api/Serviceworkers",{
        method: 'GET',
        headers: {
            'Authorization': 'Bearer ' + token,
        },
    })

        .then(res => res.json())
        .then(data =>  {
            document.getElementById('users').innerHTML = ""
    
            for(let user of data) {
                document.getElementById('users').innerHTML += `<p>${user.firstName} ${user.lastName}</p>`
            }
    
        })
        .catch(error => console.log(error))
})

logoutbutton.addEventListener("click", (e) => {
    token = ""
    users.innerHTML = ""
    sessionStorage.removeItem("token")
    localStorage.removeItem("token")
})



