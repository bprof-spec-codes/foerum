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
        basebg: "#182A4E",
        basewhitebg: "#E6E6E6"
      },
    },
  },
  variants: {
    extend: {},
  },
  plugins: [],
};
