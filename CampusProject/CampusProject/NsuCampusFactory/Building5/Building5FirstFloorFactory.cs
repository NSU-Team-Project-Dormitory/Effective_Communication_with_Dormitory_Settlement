public sealed class Building5FirstFloorFactory
{
    private readonly CampusModel _model;

    public Building5FirstFloorFactory(CampusModel model)
    {
        _model = model;
    }

    public Floor Create()
    {
        var rooms = new Dictionary<Guid, Room>();

        var room100 = new Room(_model, new Guid("{d904752a-0867-4207-866e-1b54d0db5c44}"),
            "100");
        var room102s = new Room(_model, new Guid("{BA288027-A368-434D-A815-62CF62A56C79}"),
            "102м");
        var room102b = new Room(_model, new Guid("{032dfeec-e936-4ec0-9994-c88d53d4cc91}"),
            "102б");
        var room104s = new Room(_model, new Guid("{a2a981a1-0126-492d-b313-2825b2527eec}"),
            "104м");
        var room104b = new Room(_model, new Guid("{d0baccbd-6eaf-4eda-8133-e663c3023434}"),
            "104б");
        var room105s = new Room(_model, new Guid("{a5756c55-a0ee-4bec-ae2f-d3cc6f90506f}"),
            "105м");
        var room105b = new Room(_model, new Guid("{9f557686-bb1e-4d50-941b-da40cc6ac229}"),
            "105б");
        var room106s = new Room(_model, new Guid("{be3984dd-681c-4940-9af8-e821e5909d03}"),
            "106м");
        var room106b = new Room(_model, new Guid("{72db405d-c124-4670-b23a-993a0110cf8d}"),
            "106б");
        var room107s = new Room(_model, new Guid("{a6996aa1-09af-43fa-a32d-ab72acffebde}"),
            "107м");
        var room107b = new Room(_model, new Guid("{ccf95d48-c7ae-4d72-bae7-50e899d03139}"),
            "107б");
        var room108s = new Room(_model, new Guid("{77e33468-2d66-4479-a60f-e6fcd77e9a75}"),
            "108м");
        var room108b = new Room(_model, new Guid("{255f9b66-e6ba-4be4-af52-d866f6dbfdcf}"),
             "108м");
        var room109s = new Room(_model, new Guid("{3a6054d9-d0b7-4ba3-ab1b-9a1acc03e753}"),
             "109м");
        var room109b = new Room(_model, new Guid("{7500bd9b-5222-4989-a439-51f7b62bb60f}"),
            "109б");
        var room110s = new Room(_model, new Guid("{6ae29f8f-05c1-4177-ae8d-7899d4628218}"),
            "110м");
        var room110b = new Room(_model, new Guid("{b71b1575-6ca2-4ed7-a358-a3037ab752a9}"),
            "110б");
        var room112s = new Room(_model, new Guid("{a808eca6-2edb-437e-b5b6-9241173bbf66}"),
            "112м");
        var room112b = new Room(_model, new Guid("{18c1884b-20a7-4a16-8a72-7ed7d90bf05c}"),
            "112б");
        var room120s = new Room(_model, new Guid("{99c22498-a98e-4d91-8a98-404871bdaddd}"),
            "120м");
        var room120b = new Room(_model, new Guid("{1568ff10-02cf-4478-aa3f-702f878d8ec7}"),
            "120б");
        var room119s = new Room(_model, new Guid("{50e0dd8e-613f-4d02-ab70-3b4b4323bd60}"),
            "119м");

        var room122s = new Room(_model, new Guid("{7e5fa196-7c21-409c-a361-79e478bfd8c5}"),
             "122м");
        var room122b = new Room(_model, new Guid("{ba774ac7-d1db-462f-8f0f-feb2ce91b349}"),
            "122б");
        var room124s = new Room(_model, new Guid("{be7da454-60d2-4fc9-b4b8-024d2c7f99fd}"),
            "124м");
        var room124b = new Room(_model, new Guid("{92a07912-65d5-4da8-a67e-8e88b39e4f2f}"),
            "124б");
        var room123s = new Room(_model, new Guid("{ceda9edf-308d-4130-a9ce-a25baa54a733}"),
            "123м");
        var room123b = new Room(_model, new Guid("{1a3c2484-5d04-4b3d-8174-0e8f55406d44}"),
            "123б");
        var room126s = new Room(_model, new Guid("{ed8202cb-aced-4bae-a75a-fed77720c617}"),
            "126м");
        var room126b = new Room(_model, new Guid("{15810ba1-2a99-46f7-8fc2-b35f37d1ef3e}"),
            "126б");
        var room127s = new Room(_model, new Guid("{af331fe6-afab-40d6-9b7e-17ecd8f80a8c}"),
            "127м");
        var room127b = new Room(_model, new Guid("{dd7f6b0d-2d71-4492-beab-36c6c91de10b}"),
            "127б");


        rooms.Add(room100.Id, room100);
        rooms.Add(room102s.Id, room102s);
        rooms.Add(room102b.Id, room102s);
        rooms.Add(room104s.Id, room104s);
        rooms.Add(room104b.Id, room104b);
        rooms.Add(room105s.Id, room105s);
        rooms.Add(room105b.Id, room105b);
        rooms.Add(room106s.Id, room106s);
        rooms.Add(room106b.Id, room106b);
        rooms.Add(room107s.Id, room107s);
        rooms.Add(room107b.Id, room107b);
        rooms.Add(room108s.Id, room108s);
        rooms.Add(room108b.Id, room108b);
        rooms.Add(room109s.Id, room109s);
        rooms.Add(room109b.Id, room109b);
        rooms.Add(room110s.Id, room110s);
        rooms.Add(room110b.Id, room110b);
        rooms.Add(room112s.Id, room112s);
        rooms.Add(room112b.Id, room112b);
        rooms.Add(room120s.Id, room120s);
        rooms.Add(room120b.Id, room120b);
        rooms.Add(room119s.Id, room119s);
        rooms.Add(room122b.Id, room122b);
        rooms.Add(room122s.Id, room122s);
        rooms.Add(room124b.Id, room124b);
        rooms.Add(room124s.Id, room124s);
        rooms.Add(room123b.Id, room123b);
        rooms.Add(room123s.Id, room123s);
        rooms.Add(room126b.Id, room126b);
        rooms.Add(room126s.Id, room126s);
        rooms.Add(room127b.Id, room127b);
        rooms.Add(room127s.Id, room127s);
        return new Floor(_model, new Guid("{DD656AAB-EFC8-4E35-947B-89284E781A6B}")
            , "Этаж 1", rooms);
    }
}