import React from 'react';
import './login.scss';
import logo from '../../assets/images/logo.png'

const Login = () =>{


  return (
    <div className="login">
        <div className="login__colored-container">
          <img className="login__colored-container__logo-container--image" src={logo} alt="alt" />
        </div>
        <div className={`login__login-container ${true ? 'login__login-container--active' : 'login__login-container--inactive'}`}>
            <div className="login__login-container__main-container">
                Kérlek jelentkezz be
                <div className="login__login-container__main-container__form-container">
                    <form className="login__login-container__main-container__form-container__form" onSubmit={(e) => {
                        e.preventDefault();
                    }}>
                        <input
                            className="login__login-container__main-container__form-container__form--email"
                            type="email"
                            placeholder="E-mail cím"
                            required />
                        <input
                            className="login__login-container__main-container__form-container__form--password"
                            type="password"
                            placeholder="Jelszó"
                            required />
                        <button
                            className="login__login-container__main-container__form-container__form--submit">
                            Bejelentkezés
                        </button>
                    </form>
                </div>
            </div>
        </div>
    </div>
);
}

export default Login;