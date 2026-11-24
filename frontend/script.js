const menuApiUrl = "http://localhost:5163/api/menu";

const infoElement = document.getElementById("restaurant-info");
const nameElement = document.getElementById("restaurant-name");
const taglineElement = document.getElementById("tagline");
const categoryNav = document.getElementById("category-nav");
const menuElement = document.getElementById("menu");
const footerName = document.getElementById("footer-name");
const footerInfo = document.getElementById("footer-info");

const categorySectionIds = new Map([
  ["Boot Up", "boot-up"],
  ["Main Functions", "main-functions"],
  ["Sweet Syntax", "syntax"],
  ["Fuel", "fuel"],
]);

const getCategorySectionId = (category, categoryIndex) =>
  categorySectionIds.get(category) ||
  `category-${categoryIndex + 1}`;

const formatPrice = (price) => `$${Number(price).toFixed(2)}`;

const createElement = (tagName, className, text) => {
  const element = document.createElement(tagName);
  if (className) {
    element.className = className;
  }
  if (text !== undefined) {
    element.textContent = text;
  }
  return element;
};

const menuImages = new Map([
  ["Array of Nachos", "array-of-nachos.jpg"],
  ["Boolean Bowl", "boolean-bowl.jpg"],
  ["Bubble Sort Boba", "bubble-sort-boba.jpg"],
  ["Bug Bites", "bug-bites.jpg"],
  ["Cookie Session", "cookie-session.jpg"],
  ["Full-Stack Burger", "full-stack-burger.jpg"],
  ["Hello World Fries", "hello-world-fries.jpg"],
  ["Infinite Loops", "infinite-loops.jpg"],
  ["Java", "java.jpg"],
  ["Pepperoni Pi", "pepperoni-pi.jpg"],
  ["Recursive Ramen", "recursive-ramen.jpg"],
  ["Stack Overflow Pancakes", "stack-overflow-pancakes.jpg"],
]);

const fetchJson = async (url) => {
  const response = await fetch(url);
  if (!response.ok) {
    throw new Error(`Request failed with status ${response.status}`);
  }
  return response.json();
};

const renderRestaurant = async (restaurant) => {
  nameElement.textContent = restaurant.name;
  taglineElement.textContent = restaurant.tagline;
  footerName.textContent = restaurant.name;
  footerInfo.textContent = `${restaurant.address} · ${restaurant.hours} · ${restaurant.phone}`;

  const details = [
  { text: restaurant.address, align: "min-w-0 break-words" },
  { text: restaurant.hours, align: "min-w-0 break-words sm:text-center" },
  { text: restaurant.phone, align: "min-w-0 break-words sm:text-right" },
  ];

  infoElement.replaceChildren(
    ...details.map(({ text, align }) => createElement("span", align, text)),
  );
};

const renderCategoryNav = async (categories) => {
  const items = categories.map((category, categoryIndex) => {
    const listItem = createElement("li", "shrink-0");
    const link = createElement(
      "a",
      "block  px-3 py-1.5 pt-3 pb-3 border border-stone-900 rounded-full text-xs font-black uppercase hover:bg-stone-900 hover:text-stone-100",
      category,
    );
    link.href = `#${getCategorySectionId(category, categoryIndex)}`;
    listItem.append(link);
    return listItem;
  });

  categoryNav.replaceChildren(...items);
};

const renderMenu = async (items) => {
  const categories = [...new Set(items.map((item) => item.category))].filter(
    Boolean,
  );

  const sections = categories.map((category, categoryIndex) => {
    const categoryItems = items.filter((item) => item.category === category);
    const number = String(categoryIndex + 1).padStart(2, "0");

    const cards = categoryItems.map((item) => {
      const article = createElement("article", "min-w-0");

      const image = createElement(
        "img",
        "block w-full h-30 object-cover bg-stone-300 sm:h-45",
      );
      image.src = `images/${menuImages.get(item.name) || "java.jpg"}`;
      image.alt = item.name;
     

      const titleRow = createElement(
        "div",
        "mt-2.5 flex items-baseline justify-between gap-2",
      );
      titleRow.append(
        createElement("h3", "text-xl leading-[0.5] font-black", item.name),
        createElement(
          "p",
          "shrink-0 text-xl leading-[0.5] font-black text-orange-700",
          formatPrice(item.price),
        ),
      );

      const description = createElement(
        "p",
        "min-h-[30px] mt-[6px] mb-1 text-lg text-stone-600",
        item.description,
      );
      const tag = createElement(
        "span",
        "inline-block px-1 py-0.5 border border-stone-300 rounded-full text-xs leading-none font-black uppercase text-stone-600",
        item.tag,
      );

      article.appendChild(image);
      article.appendChild(titleRow);
      article.appendChild(description);
      article.appendChild(tag);
      return article;
    });

    const sectionId = getCategorySectionId(category, categoryIndex);
    let section = document.getElementById(sectionId);

    if (!section) {
      section = createElement(
        "section",
        "",
      );
      section.id = sectionId;
      menuElement.appendChild(section);
    }

    section.className =
      "py-7 pb-8.5 border-b border-stone-900 scroll-mt-16 last:border-b-0";
    section.replaceChildren();

    const headingRow = createElement(
      "div",
      "mb-4.5 flex items-end justify-between",
    );
    headingRow.append(
      createElement(
        "h2",
        "text-4xl leading-[0.9]  font-black uppercase sm:text-5xl lg:text-6xl",
        category,
      ),
      createElement(
        "span",
        "text-[19px] leading-none font-serif italic text-orange-700",
        number,
      ),
    );

 const cardGrid = createElement(
  "div",
  "grid grid-cols-1 gap-y-6 sm:grid-cols-2 sm:gap-x-5 sm:gap-y-7 lg:grid-cols-3",
);
    cards.forEach((card) => {
      cardGrid.appendChild(card);
    });

    section.appendChild(headingRow);
    section.appendChild(cardGrid);
    return section;
  });

  document.getElementById("status")?.remove();

  await renderCategoryNav(categories);
};

const initializeMenu = async () => {
  try {
    const [restaurant, items] = await Promise.all([
      fetchJson(`${menuApiUrl}/restaurant`),
      fetchJson(menuApiUrl),
    ]);

    await renderRestaurant(restaurant);
    await renderMenu(items);
  } catch (error) {
    const message = createElement(
      "p",
      "py-10 text-center font-black text-orange-700",
      "Sorry, the menu could not be loaded.",
    );
    message.setAttribute("role", "alert");
    menuElement.replaceChildren(message);
    console.log(error);
  }
};

initializeMenu();
