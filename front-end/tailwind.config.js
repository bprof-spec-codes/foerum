module.exports = {
  purge: ["./src/**/*.{js,jsx,ts,tsx}", "./public/index.html"],
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {
      fontSize: {
        verybig: "120px",
      },
      textColor: {
        oeyellow: "#FAB001",
      },
      colors: {
        basebg: "#0E1B38",
      },
    },
  },
  variants: {
    extend: {},
  },
  plugins: [],
};
