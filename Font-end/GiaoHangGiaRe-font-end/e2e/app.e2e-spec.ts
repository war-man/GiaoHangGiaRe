import { GiaoHangGiaReFontEndPage } from './app.po';

describe('giao-hang-gia-re-font-end App', function() {
  let page: GiaoHangGiaReFontEndPage;

  beforeEach(() => {
    page = new GiaoHangGiaReFontEndPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
