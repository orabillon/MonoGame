using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using TiledSharp;

namespace Tiled
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //MAp
        TmxMap _map;
        Texture2D _tileset;
        int tileWidth;
        int tileHeight;
        int mapWidth;
        int mapHeight;
        int tilesetColumns;
        int tilesetLines;



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _map = new TmxMap("Content/map.tmx");
            _tileset = Content.Load<Texture2D>(_map.Tilesets[0].Name);
            tileHeight = _map.Tilesets[0].TileHeight;
            tileWidth = _map.Tilesets[0].TileWidth;
            mapWidth = _map.Width;
            mapHeight = _map.Height;
            tilesetColumns = _tileset.Width / tileWidth;
            tilesetLines = _tileset.Height / tileHeight;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            int nbLayer = _map.Layers.Count;
            int lin; int col;

            for (int nLayer = 0; nLayer < nbLayer; nLayer++)
            {
                lin = 0; col = 0;

                for (int i = 0; i < _map.TileLayers[nLayer].Tiles.Count; i++)
                {
                    int gId = _map.TileLayers[nLayer].Tiles[i].Gid;

                    int TileFrame = gId - 1;
                    int TilesetColumn = TileFrame % tilesetColumns;
                    int TilesetLine = (int)Math.Floor((double)TileFrame / (double)tilesetColumns);

                    float x = col * tileWidth;
                    float y = lin * tileHeight;

                    Rectangle tilesetRec = new Rectangle(
                                tileWidth * TilesetColumn,
                                tileHeight * TilesetLine,
                                tileWidth, tileHeight);

                    _spriteBatch.Draw(_tileset, new Vector2(x, y), tilesetRec, Color.White);

                    col++;
                    if (col == mapWidth)
                    {
                        col = 0;
                        lin++;
                    }

                }

            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
