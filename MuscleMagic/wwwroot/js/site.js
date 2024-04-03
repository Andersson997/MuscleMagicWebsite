const navSlide = () =>
{
    const nav = document.querySelector(".nav-links");
    const navLinks = document.querySelectorAll(".nav-links li");
    const burger = document.querySelectorAll(".burger");

    if (burger)
    {
        burger.forEach((burger, index) =>
        {
            burger.addEventListener("click", () =>
            {
            nav.classList.toggle("nav-active");
            burger.classList.toggle("toggle");
             });

            navLinks.forEach((link, index) =>
            {
                if (link.style.animation)
                {
                link.style.animation = "";
                }
                else
                {
                link.style.animation = `navLinkFade 0.5s ease forwards ${index / 7 + 0.2
                    }s`;
                }
            });
        });
    }
};

const loginModal = () =>
{
    const cancelbtn1 = document.getElementById("cancel-modal1");
    const cancelbtn2 = document.getElementById("cancel-modal2");
    const modal = document.querySelector(".loginsignup-container");
    const scroll = document.querySelector("body")
    
    const loginbtn = document.querySelector(".loginbtn");

    if (loginbtn) {
        loginbtn.addEventListener("click", () => {
            modal.classList.toggle("modal-active");
            scroll.classList.toggle("scroll-inactive");
        });
    }
        if (cancelbtn1) {
            cancelbtn1.addEventListener("click", () => {
                modal.classList.toggle("modal-active");
                scroll.classList.toggle("scroll-inactive")
            });
        }

        if (cancelbtn2) {
            cancelbtn2.addEventListener("click", () => {
                modal.classList.toggle("modal-active");
                scroll.classList.toggle("scroll-inactive")
            });
        }
    
}
const signUpButton = document.getElementById("signUp");
const signInButton = document.getElementById("signIn");
const container = document.getElementById("loginsignup");

    if (signUpButton)
    {
        signUpButton.addEventListener("click", () =>
        {
        container.classList.add("right-panel-active");
        });
    }
    if (signInButton)
    {
        signInButton.addEventListener("click", () =>
        {
        container.classList.remove("right-panel-active");
        });
    }

const logoutbtn = document.getElementById("logout");


if (logoutbtn) {
    logoutbtn.addEventListener("click", () => {
        location.href='@Url.Action("SignOutUser", "Home")' 
    });
}
    

const modal2 = document.querySelector(".loginsignup-container");
const scroll = document.querySelector("body")
    window.onclick = function (event)
    {
        if (event.target == modal2)
        {
            modal2.classList.toggle("modal-active");
            scroll.classList.toggle("scroll-inactive")
        }
    };

    $(document).keyup(function (e)
    {
        if (e.keyCode === 27)
        {
        modal2.classList.remove("modal-active");
        }
    });

$("#login").click(function () {
  
    let Email = document.getElementById("email2");
    let Password = document.getElementById("password2");

    $.ajax({
        url: "Home/Index",
        dataType: "Json",
        data:
            {email: Email.value, password: Password.value },
        type: "POST",
        success: function (data) {
            if (data) {
                window.location.replace("Home/Myaccount");
            }
            else {
                $("#incorrect-credentials").text("Incorrect username or password");
            }


        }
    });
});


$("#register").click(function () {
    let Fname = document.getElementById("fname");
    let Lname = document.getElementById("lname");
    let Email = document.getElementById("email");
    let Password = document.getElementById("password");
    
    $.ajax({
        url: "Home/Register",
        dataType: "Json",
        data:
            { fname: Fname.value, lname: Lname.value, email: Email.value, password: Password.value},
        type: "POST",
        success: function (data) {
            if (data) {
                window.location.replace("Home/Myaccount");
            }
            else {
                $("#errormsg").text("Username already exists");
            }
        }
    });
});

loginModal();
navSlide();

