import { useState } from 'react';
import MenuItem from './MenuItem/MenuItem.js';
import { menuItems } from './MenuConstants.js';

import './Menu.css';

const Menu = ({
    onMenuItemClick
}) => {
    const [currentItem, setCurrentItem] = useState();

    const menuItemClickHandler = (id) => {
        setCurrentItem(id);
        onMenuItemClick(id);
    }

    return (
        <aside className="menu">
            {menuItems.map(x =>
                <MenuItem
                    key={x.id}
                    id={x.id}
                    isSelected={x.id == currentItem}
                    onClick={menuItemClickHandler}
                >
                    {x.text}
                </MenuItem>
            )}
        </aside>
    );
};

export default Menu;