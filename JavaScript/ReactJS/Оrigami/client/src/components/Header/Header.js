import style from './Header.module.css';
import navStyle from './NavigationItem/NavigationItem.module.css';
import NavigationItem from './NavigationItem/NavigationItem.js';

import { Link, NavLink } from 'react-router-dom';

const Header = () => {
    return (
        <nav className={style.navigation}>
            <ul>
                <li className={navStyle.listItem}><img src="/white-origami-bird.png" alt="white origami" /></li>
                <NavLink to="/"><NavigationItem>Home</NavigationItem></NavLink>
                <NavLink to="/about"><NavigationItem>About</NavigationItem></NavLink>
                <NavLink to="/about/1"><NavigationItem>Going to 1</NavigationItem></NavLink>
                <NavLink to="/about/2"><NavigationItem>Going to 2</NavigationItem></NavLink>
                <NavLink className={(navData) => navData.isActive ? "active-nav-item" : ""} to="/about/3"><NavigationItem>Going to 3</NavigationItem></NavLink>
                <NavLink style={({ isActive }) => ({ backgroundColor: isActive ? 'red' : "" })} to="/about/4"><NavigationItem>Going to 4</NavigationItem></NavLink>
                <NavLink to="/about/5"><NavigationItem>Going to 5</NavigationItem></NavLink>
                <NavLink to="/about/10"><NavigationItem>Going to 10</NavigationItem></NavLink>
            </ul>
        </nav>
    );
};

export default Header;